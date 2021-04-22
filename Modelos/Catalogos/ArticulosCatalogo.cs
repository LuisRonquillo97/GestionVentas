using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelos.Catalogos
{
    public class ArticulosCatalogo : IMetodosCatalogo<ArticulosEntity>
    {
        private readonly SqlServerContext Context;
        public Exception Error { get; set; }
        public ArticulosCatalogo()
        {
            Context = new SqlServerContext();
        }
        public bool Agregar(ArticulosEntity model)
        {
            try
            {
                model.Id = null;
                Context.Articulos.Add(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public ArticulosEntity BuscarPorId(int id)
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

        public List<ArticulosEntity> Listar(ArticulosEntity filtros=null)
        {
            if (filtros == null)
            {
                return Context.Articulos.Where(x => x.Activo).ToList();
            }
            else
            {
                var articulos = Context.Articulos.Where(x => x.Activo == filtros.Activo).ToList();
                if (filtros.Id.HasValue) articulos = articulos.Where(x => x.Id.Value == filtros.Id.Value).ToList();
                if (!string.IsNullOrEmpty(filtros.Descripcion)) articulos = articulos.Where(x => x.Descripcion.Contains(filtros.Descripcion)).ToList();
                if (filtros.Existencia.HasValue) articulos = articulos.Where(x => x.Existencia.Value == filtros.Existencia.Value).ToList();
                if (filtros.Impuesto.HasValue) articulos = articulos.Where(x => x.Impuesto.Value == filtros.Impuesto.Value).ToList();
                if (filtros.PrecioVenta.HasValue) articulos = articulos.Where(x => x.PrecioVenta.Value == filtros.PrecioVenta.Value).ToList();
                return articulos;
            }
        }

        public bool Modificar(ArticulosEntity model)
        {
            try
            {
                var articulo = Context.Articulos.FirstOrDefault(x => x.Id.Value == model.Id.Value);
                articulo.Descripcion = model.Descripcion;
                articulo.Existencia = model.Existencia;
                articulo.Impuesto = model.Impuesto;
                articulo.PrecioVenta = model.PrecioVenta;
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }
    }
}
