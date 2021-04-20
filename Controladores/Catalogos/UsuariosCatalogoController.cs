using AutoMapper;
using Controladores.Data;
using Controladores.Mapper;
using Modelos.Catálogos;
using Modelos.Entities;
using System.Collections.Generic;

namespace Controladores.Catalogos
{
    public class UsuariosCatalogoController
    {
        private readonly UsuariosCatalogo usuariosCatalogo;
        public UsuariosCatalogoController()
        {
            usuariosCatalogo = new UsuariosCatalogo();
        }
        public UsuariosEntity GenerarEntidad(int? id, string nombre, string nombreUsuario, string contraseña)
        {
            return new UsuariosEntity() { Id = id ?? 0, Nombre = nombre, NombreUsuario = nombreUsuario, Contraseña = contraseña };
        }
        public string Agregar(string nombre, string nombreUsuario, string contraseña)
        {
            UsuariosEntity Usuario = GenerarEntidad(null, nombre, nombreUsuario, contraseña);
            if (usuariosCatalogo.Agregar(Usuario))
            {
                return "Usuario agregado correctamente.";
            }
            else
            {
                return "Error al agregar usuario:\n" + usuariosCatalogo.Error.Message;
            }
        }
        public string Modificar(int id, string nombre, string nombreUsuario, string contraseña)
        {
            UsuariosEntity usuario = GenerarEntidad(id, nombre, nombreUsuario, contraseña);
            if (usuariosCatalogo.Modificar(usuario))
            {
                return "Usuario modificado correctamente.";
            }
            else
            {
                return "Error al modificar usuario:\n" + usuariosCatalogo.Error.Message;
            }
        }
        public string Desactivar(int id)
        {
            if (usuariosCatalogo.Eliminar(id))
            {
                return "Usuario eliminado correctamente.";
            }
            else
            {
                return "Error al eliminar usuario:\n" + usuariosCatalogo.Error.Message;
            }
        }
        public List<UsuariosData> ListarUsuarios(int? id, string nombre, string nombreUsuario, string contraseña)
        {
            UsuariosEntity usuario;
            if (id.HasValue || !string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(nombreUsuario) || !string.IsNullOrEmpty(contraseña))
            {
                usuario = GenerarEntidad(id, nombre, nombreUsuario, contraseña);
                return new UsuarioMapper().MapList(usuariosCatalogo.Listar(usuario));
            }
            else
            {
                return new UsuarioMapper().MapList(usuariosCatalogo.Listar());
            }

        }
        public UsuariosData BuscarPorId(int id)
        {
            return new UsuarioMapper().Map(usuariosCatalogo.BuscarPorId(id));
        }
        public string IniciarSesion(string usuario, string contraseña)
        {
            if (!usuariosCatalogo.IniciarSesion(usuario, contraseña))
            {
                return "Error al iniciar sesión:\n"+usuariosCatalogo.Error.Message;
            }
            else
            {
                return "";
            }
        }

    }
}
