using Modelos.Interfaces;
using Modelos.Entities;
using Modelos.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelos.Catalogos
{
    public class TiposPagoCatalogo : IMetodosCatalogo<TipoPagoEntity>
    {
        public Exception Error { get; set; }
        private readonly SqlServerContext Context = new SqlServerContext();
        public TiposPagoCatalogo()
        {
            Context = new SqlServerContext();
        }
        

        public bool Agregar(TipoPagoEntity model)
        {
            try
            {
                if (Validar(model))
                {
                    Context.TiposPago.Add(model);
                    Context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception e)
            {
                Error = e;
                return false;
            }
            
        }

        public TipoPagoEntity BuscarPorId(int id)
        {
            return Context.TiposPago.FirstOrDefault(x => x.Id == id);
        }

        public bool Eliminar(int Id)
        {
            try
            {
                Context.TiposPago.FirstOrDefault(x => x.Id.Value == Id).Activo = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public List<TipoPagoEntity> Listar(TipoPagoEntity filtros=null)
        {
            if (filtros == null)
            {
                return Context.TiposPago.Where(x => x.Activo).ToList();
            }
            else
            {
                var tiposPago = Context.TiposPago.Where(x => x.Activo);
                if (filtros.Id.HasValue) tiposPago = tiposPago.Where(x => x.Id.Value == filtros.Id.Value);
                if (!string.IsNullOrEmpty(filtros.Descripcion)) tiposPago = tiposPago.Where(x => x.Descripcion.Contains(filtros.Descripcion));
                return tiposPago.ToList();
            }
        }

        public bool Modificar(TipoPagoEntity model)
        {
            try
            {
                if (Validar(model, true))
                {
                    var tipoPago = Context.TiposPago.FirstOrDefault(x => x.Id.Value == model.Id.Value);
                    if (tipoPago != null)
                    {
                        tipoPago.Descripcion = model.Descripcion;
                        Context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        Error = new Exception("El tipo de pago no se encontró.");
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

        public bool Validar(TipoPagoEntity model, bool update = false)
        {
            if (update)
            {
                if (model.Id.Value <= 0)
                {
                    Error = new Exception("ID inválido.");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(model.Descripcion))
            {
                Error = new Exception("Descripción no puede estar vacío.");
                return false;
            }
            return true;
        }
    }
}
