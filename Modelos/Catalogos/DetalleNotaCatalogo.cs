using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelos.Catalogos
{
    public class DetalleNotaCatalogo : IMetodosCatalogo<DetalleNotaEntity>
    {
        public readonly SqlServerContext Context;
        public DetalleNotaCatalogo()
        {
            Context = new SqlServerContext();
        }
        public Exception Error { get; set; }

        public bool Agregar(DetalleNotaEntity model)
        {
            try
            {
                if (Validar(model))
                {
                    Context.DetallesNota.Add(model);
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

        public DetalleNotaEntity BuscarPorId(int id)
        {
            return Context.DetallesNota.FirstOrDefault(x => x.Id == id);
        }

        public bool Eliminar(int Id)
        {
            try
            {
                Context.DetallesNota.FirstOrDefault(x => x.Id.Value == Id).Activo = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public List<DetalleNotaEntity> Listar(DetalleNotaEntity filtros = null)
        {
            if (filtros == null)
            {
                return Context.DetallesNota.ToList();
            }
            else
            {
                IQueryable<DetalleNotaEntity> DetallesNota = Context.DetallesNota.Where(x => x.Activo);
                if (filtros.Id.HasValue) DetallesNota = DetallesNota.Where(x => x.Id.Value == filtros.Id.Value);
                if (filtros.Cantidad.HasValue) DetallesNota = DetallesNota.Where(x => x.Cantidad.Value == filtros.Cantidad.Value);
                if (filtros.IdArticulo.HasValue) DetallesNota = DetallesNota.Where(x => x.IdArticulo.Value == filtros.IdArticulo.Value);
                if (filtros.IdEncabezadoNota.HasValue) DetallesNota = DetallesNota.Where(x => x.IdEncabezadoNota.Value == filtros.IdEncabezadoNota.Value);
                if (filtros.PrecioVenta.HasValue) DetallesNota = DetallesNota.Where(x => x.PrecioVenta.Value == filtros.PrecioVenta.Value);
                return DetallesNota.ToList();
            }
        }

        public bool Modificar(DetalleNotaEntity model)
        {
            try
            {
                if (Validar(model, true))
                {
                    var detallesNota = Context.DetallesNota.FirstOrDefault(x => x.Id.Value == model.Id.Value);
                    if (detallesNota != null)
                    {
                        detallesNota.IdArticulo = model.IdArticulo;
                        detallesNota.IdEncabezadoNota = model.IdEncabezadoNota;
                        detallesNota.PrecioVenta = model.PrecioVenta;
                        detallesNota.Cantidad = model.Cantidad;
                        Context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Error = new Exception("El detalle de nota de venta no se encontró.");
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

        public bool Validar(DetalleNotaEntity model, bool update = false)
        {
            if (update)
            {
                if (model.Id.Value <= 0)
                {
                    Error = new Exception("ID inválido.");
                    return false;
                }
            }
            if (model.Cantidad.HasValue)
            {
                if (model.Cantidad.Value <= 0)
                {
                    Error = new Exception("La cantidad vendida tiene que ser mayor a cero.");
                    return false;
                }
            }
            else
            {
                Error = new Exception("La cantidad vendida tiene que ser mayor a cero.");
                return false;
            }
            if (!model.IdArticulo.HasValue)
            {
                Error = new Exception("El Id de artículo no puede estar vacío.");
                return false;
            }
            if (!model.IdEncabezadoNota.HasValue)
            {
                Error = new Exception("El estatus no puede estar vacío.");
                return false;
            }
            if (!model.PrecioVenta.HasValue)
            {
                Error = new Exception("El estatus no puede estar vacío.");
                return false;
            }
            return true;
        }
    }
}
