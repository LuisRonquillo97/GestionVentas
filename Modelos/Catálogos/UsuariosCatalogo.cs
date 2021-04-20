using System;
using System.Collections.Generic;
using System.Linq;
using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;

namespace Modelos.Catálogos
{
    public class UsuariosCatalogo : IMetodosCatalogo<UsuariosEntity>
    {
        private readonly SqlServerContext Context;
        public Exception Error { get; set; }
        public UsuariosCatalogo()
        {
            Context = new SqlServerContext();
        }

        public bool Agregar(UsuariosEntity model)
        {
            try
            {
                model.Id = null;
                Context.Usuarios.Add(model);
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }

        }

        public UsuariosEntity BuscarPorId(int id)
        {
            return Context.Usuarios.FirstOrDefault(f => f.Id == id);
        }

        public bool Eliminar(int Id)
        {
            try
            {
                Context.Usuarios.FirstOrDefault(f => f.Id == Id).Activo = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Error = e;
                return false;
            }
        }

        public List<UsuariosEntity> Listar(UsuariosEntity filtros = null)
        {
            if (filtros != null)
            {
                List<UsuariosEntity> UsuariosList = Context.Usuarios.ToList();
                if (filtros.Id.HasValue) UsuariosList=UsuariosList.Where(x => x.Id.Value == filtros.Id.Value).ToList();
                if (!string.IsNullOrEmpty(filtros.Nombre)) UsuariosList = UsuariosList.Where(x => x.Nombre.Contains(filtros.Nombre)).ToList();
                if(!string.IsNullOrEmpty(filtros.NombreUsuario)) UsuariosList = UsuariosList.Where(x => x.NombreUsuario.Contains(filtros.NombreUsuario)).ToList();
                if(!string.IsNullOrEmpty(filtros.Contraseña)) UsuariosList = UsuariosList.Where(x => x.Contraseña.Contains(filtros.Contraseña)).ToList();
                UsuariosList = UsuariosList.Where(x => x.Activo == filtros.Activo).ToList();

                return UsuariosList;
            }
            else
            {
                return Context.Usuarios.Where(w => w.Activo).ToList();
            }
        }

        public bool Modificar(UsuariosEntity model)
        {
            try
            {
                var usuario = Context.Usuarios.FirstOrDefault(f => f.Id.Value == model.Id.Value);
                usuario.Nombre = model.Nombre;
                usuario.NombreUsuario = model.NombreUsuario;
                usuario.Contraseña = model.Contraseña;
                Context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                Error = e;
                return false;
            }
        }
        public bool IniciarSesion(string usuario, string contraseña)
        {
            if(!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contraseña))
            {
                var result = Context.Usuarios.FirstOrDefault(x => x.NombreUsuario==usuario && x.Contraseña==contraseña);
                if (result != null)
                {
                    return true;
                }
                else
                {
                    Error = new Exception("Usuario o contraseña inválidos");
                    return false;
                }
            }
            else
            {
                Error = new Exception("Debe ingresar un nombre de usuario y contraseña.");
                return false;
            }
            
        }
    }
}
