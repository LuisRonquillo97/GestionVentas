using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelos.Catalogos
{
    public class ArticulosCatalogo : IMetodosCatalogo<ArticuloEntity>
    {
        private readonly SqlServerContext Context;
        public Exception Error { get; set; }
        public ArticulosCatalogo()
        {
            Context = new SqlServerContext();
        }
        public bool Agregar(ArticuloEntity model)
        {
            try
            {
                if (Validar(model))
                {
                    model.Id = null;
                    Context.Articulos.Add(model);
                    Context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
                
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public ArticuloEntity BuscarPorId(int id)
        {
            return Context.Articulos.FirstOrDefault(x => x.Id.Value == id);
        }

        public bool Eliminar(int Id)
        {
            try
            {
                Context.Articulos.FirstOrDefault(x => x.Id.Value == Id).Activo = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public List<ArticuloEntity> Listar(ArticuloEntity filtros=null)
        {
            if (filtros == null)
            {
                return Context.Articulos.Where(x => x.Activo).ToList();
            }
            else
            {
                var articulos = Context.Articulos.Where(x=>x.Activo).ToList();
                if (filtros.Id.HasValue) articulos = articulos.Where(x => x.Id.Value == filtros.Id.Value).ToList();
                if (!string.IsNullOrEmpty(filtros.Descripcion)) articulos = articulos.Where(x => x.Descripcion.Contains(filtros.Descripcion)).ToList();
                if (filtros.Existencia.HasValue) articulos = articulos.Where(x => x.Existencia.Value == filtros.Existencia.Value).ToList();
                if (filtros.Impuesto.HasValue) articulos = articulos.Where(x => x.Impuesto.Value == filtros.Impuesto.Value).ToList();
                if (filtros.PrecioVenta.HasValue) articulos = articulos.Where(x => x.PrecioVenta.Value == filtros.PrecioVenta.Value).ToList();
                return articulos;
            }
        }

        public bool Modificar(ArticuloEntity model)
        {
            try
            {
                if (Validar(model,true))
                {
                    var articulo = Context.Articulos.FirstOrDefault(x => x.Id.Value == model.Id.Value);
                    if (articulo != null)
                    {
                        articulo.Descripcion = model.Descripcion;
                        articulo.Existencia = model.Existencia;
                        articulo.Impuesto = model.Impuesto;
                        articulo.PrecioVenta = model.PrecioVenta;
                        Context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Error = new Exception("El articulo no se encontró.");
                        return false;
                    }
                    
                }
                else
                {
                    return false;
                }
                    
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public bool Validar(ArticuloEntity model,bool update=false)
        {
            if (update)
            {
                if (model.Id.Value <= 0)
                {
                    Error = new Exception("ID inválido.");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(model.Descripcion) || model.Descripcion.Length>100)
            {
                Error = new Exception("Descripción inválida.");
                return false;
            }
            if (model.Existencia < 0)
            {
                Error = new Exception("Las existencias del artículo no pueden ser menores a cero.");
                return false;
            }
            if (model.PrecioVenta <= 0)
            {
                Error = new Exception("El precio de venta debe de ser mayor a cero.");
                return false;
            }
            if (model.Impuesto < 0)
            {
                Error = new Exception("El impuesto del artículo debe ser mayor a cero.");
                return false;
            }
            return true;
        }
    }
}
