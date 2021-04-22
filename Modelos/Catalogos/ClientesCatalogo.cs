using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Modelos.Catalogos
{
    public class ClientesCatalogo : IMetodosCatalogo<ClienteEntity>
    {
        private readonly SqlServerContext Context;
        public Exception Error { get; set; }
        public ClientesCatalogo()
        {
            Context = new SqlServerContext();
        }
        public bool Agregar(ClienteEntity model)
        {
            try
            {
                if (Validar(model))
                {
                    model.Id = null;
                    Context.Clientes.Add(model);
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

        public ClienteEntity BuscarPorId(int id)
        {
            return Context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public bool Eliminar(int Id)
        {
            try
            {
                Context.Clientes.FirstOrDefault(x => x.Id.Value == Id).Activo = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public List<ClienteEntity> Listar(ClienteEntity filtros=null)
        {
            if (filtros == null)
            {
                return Context.Clientes.Where(x => x.Activo).ToList();
            }
            else
            {
                IQueryable<ClienteEntity> clientes = Context.Clientes.Where(x => x.Activo);
                if (filtros.Id.HasValue) clientes = clientes.Where(x => x.Id.Value == filtros.Id.Value);
                if (!string.IsNullOrEmpty(filtros.Direccion)) clientes = clientes.Where(x => x.Direccion.Contains(filtros.Direccion));
                if (!string.IsNullOrEmpty(filtros.NombreCompleto)) clientes = clientes.Where(x => x.NombreCompleto.Contains(filtros.NombreCompleto));
                if (!string.IsNullOrEmpty(filtros.Rfc)) clientes = clientes.Where(x => x.Rfc.Contains(filtros.Rfc));
                return clientes.ToList();
            }
        }

        public bool Modificar(ClienteEntity model)
        {
            try
            {
                if (Validar(model, true))
                {
                    var cliente = Context.Clientes.FirstOrDefault(x => x.Id.Value == model.Id.Value);
                    cliente.Direccion = model.Direccion;
                    cliente.NombreCompleto = model.NombreCompleto;
                    cliente.Rfc = model.Rfc;
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

        public bool Validar(ClienteEntity model, bool update = false)
        {
            if (update)
            {
                if (model.Id.Value <= 0)
                {
                    Error = new Exception("ID inválido.");
                    return false;
                }
            }
            if (string.IsNullOrEmpty(model.Direccion))
            {
                Error = new Exception("ID inválido.");
                return false;
            }
            if (string.IsNullOrEmpty(model.NombreCompleto))
            {
                Error = new Exception("El nombre del cliente no puede estar vacío.");
                return false;
            }
            return true;
        }
    }
}
