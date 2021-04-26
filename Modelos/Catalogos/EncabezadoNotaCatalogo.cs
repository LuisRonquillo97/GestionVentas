using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Modelos.Catalogos
{
    public class EncabezadoNotaCatalogo : IMetodosCatalogo<EncabezadoNotaEntity>
    {
        public readonly SqlServerContext Context;
        public EncabezadoNotaCatalogo()
        {
            Context = new SqlServerContext();
        }
        public Exception Error { get; set; }

        public bool Agregar(EncabezadoNotaEntity model)
        {
            try
            {
                if (Validar(model))
                {
                    Context.EncabezadosNota.Add(model);
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

        public EncabezadoNotaEntity BuscarPorId(int id)
        {
            return Context.EncabezadosNota.Include(x=>x.Cliente).Include(x=>x.TipoPago).FirstOrDefault(x => x.Id == id);
        }

        public bool Eliminar(int Id)
        {
            try
            {
                Context.EncabezadosNota.FirstOrDefault(x => x.Id.Value == Id).Status = "Cancelado";
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public List<EncabezadoNotaEntity> Listar(EncabezadoNotaEntity filtros = null)
        {
            if (filtros == null)
            {
                return Context.EncabezadosNota.Include(x=>x.Cliente).Include(x=>x.TipoPago).ToList();
            }
            else
            {
                IQueryable<EncabezadoNotaEntity> encabezadosNota = Context.EncabezadosNota.Include(x=>x.Cliente).Include(x => x.TipoPago);
                if (filtros.Id.HasValue) encabezadosNota = encabezadosNota.Where(x => x.Id.Value == filtros.Id.Value);
                if (!string.IsNullOrEmpty(filtros.Comentario)) encabezadosNota = encabezadosNota.Where(x => x.Comentario.Contains(filtros.Comentario));
                if (filtros.FechaCreado.HasValue) encabezadosNota = encabezadosNota.Where(x => x.FechaCreado.Value.Date==filtros.FechaCreado.Value.Date);
                if (filtros.IdCliente.HasValue) encabezadosNota = encabezadosNota.Where(x => x.IdCliente.Value==filtros.IdCliente.Value);
                if (filtros.IdTipoPago.HasValue) encabezadosNota = encabezadosNota.Where(x => x.IdTipoPago.Value==filtros.IdTipoPago.Value);
                if (!string.IsNullOrEmpty(filtros.Status)) encabezadosNota = encabezadosNota.Where(x => x.Status.Contains(filtros.Status));
                return encabezadosNota.ToList();
            }
        }

        public bool Modificar(EncabezadoNotaEntity model)
        {
            try
            {
                if (Validar(model, true))
                {
                    var tipoPago = Context.EncabezadosNota.FirstOrDefault(x => x.Id.Value == model.Id.Value);
                    if (tipoPago != null)
                    {
                        tipoPago.Comentario = model.Comentario;
                        tipoPago.FechaCreado = model.FechaCreado;
                        tipoPago.IdCliente = model.IdCliente;
                        tipoPago.IdTipoPago = model.IdTipoPago;
                        tipoPago.Status = model.Status;
                        Context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Error = new Exception("El Encabezado de nota de venta no se encontró.");
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

        public bool Validar(EncabezadoNotaEntity model, bool update = false)
        {
            if (update)
            {
                if (model.Id.Value <= 0)
                {
                    Error = new Exception("ID inválido.");
                    return false;
                }
            }
            if (model.IdCliente.HasValue == false)
            {
                Error = new Exception("El cliente no puede estar vacío.");
                return false;
            }
            if (model.IdTipoPago.HasValue == false)
            {
                Error = new Exception("El tipo de pago no puede estar vacío.");
                return false;
            }
            if (string.IsNullOrEmpty(model.Status))
            {
                Error = new Exception("El estatus no puede estar vacío.");
                return false;
            }
            return true;
        }
    }
}
