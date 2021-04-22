using System;
using System.Collections.Generic;
using System.Linq;
using Modelos.Contexts;
using Modelos.Entities;
using Modelos.Interfaces;

namespace Modelos.Catalogos
{
    /*
     * Clase en la que se realizan los movimientos de base de datos.
     * se utiliza la interfaz IMetodosCatalogo con la entidad de usuarios.
     * el <T> de la interfaz, aquí será UsuariosEntity.
     */
    public class UsuariosCatalogo : IMetodosCatalogo<UsuariosEntity>
    {
        //inicializamos el contexto de SQL server, que será en nuestra máquina local. Si no hacemos esto, no podremos editar nuestra base de datos.
        private readonly SqlServerContext Context;
        //También inicializamos la excepción por si ocurriera algún problema
        public Exception Error { get; set; }
        //en el constructor, inicializamos el contexto de SQL server.
        public UsuariosCatalogo()
        {
            Context = new SqlServerContext();
        }
        /*
         * Método agregar, recibe un UsuarioEntity, que será el que agregue a BD.
         * devuelve un booleano true/false.
         * si devuelve false, la excepción que arroje se guarda en la variable error.
         */
        public bool Agregar(UsuariosEntity model)
        {
            try
            {
                //como se está agregando y el ID es autoincremental, no necesitamos que ID tenga valor, así que 
                //lo asignamos nulo para evitar errores
                model.Id = null;
                //agregamos el usuario a la tabla usuarios
                Context.Usuarios.Add(model);
                //mandamos a guardar los cambios a base de datos
                Context.SaveChanges();
                //si todo ocurrió sin problemas, devolvemos true-
                return true;
            }
            //si por alguna razón hay un error, se crea una excepción llamada e.
            catch (Exception e)
            {
                //le damos a Error la excepción, y devolvemos false.
                Error = e;
                return false;
            }

        }

        /*
         * BuscarPorId necesita un ID que es tipo int para buscar.
         * devuelve un UsuarioEntity que tendrá los datos del usuario que buscó.
         * si no encuentra ningún usuario, devolverá null.
         */
        public UsuariosEntity BuscarPorId(int id)
        {
            return Context.Usuarios.FirstOrDefault(f => f.Id == id);
        }

        /*
         * Eliminar necesita un ID que es tipo int para saber qué va a eliminar.
         * busca el elemento y le cambia el parámetro activo a false, así que lo "desactiva" en vez de eliminar el registro.
         * si no encuentra el registro no borra nada.
         */
        public bool Eliminar(int Id)
        {
            try
            {
                //buscamos el registro, lo desactivamos y guardamos los cambios.
                Context.Usuarios.FirstOrDefault(f => f.Id == Id).Activo = false;
                Context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                //si ocurriera un error en el bloque de código del try, guardamos el error e en Error, y devolvemos false.
                Error = e;
                return false;
            }
        }

        /*
         * Método listar, sirve para obtener el listado de usuarios que tengamos en BD.
         * tenemos un parámetro opcional de tipo UsuariosEntity llamado filtros que por default es null.
         * es decir, si no pasamos ese parámetro será null.
         * por defecto, devuelve un listado de todos los usuarios activos.
         * si se tienen filtros, realiza el filtro de todos los datos posibles, y devuelve el resultado de la búsqueda.
         */
        public List<UsuariosEntity> Listar(UsuariosEntity filtros = null)
        {
            //verificamos si hay filtros
            if (filtros != null)
            {
                //si hay, obtenemos el listado de todos y vamos filtrando campo por campo, revisando antes que nada, que cada campo
                //tenga un valor
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
                //si no hay filtros, enviamos el listado de sólo los registros activos.
                return Context.Usuarios.Where(w => w.Activo).ToList();
            }
        }
        /*
         * Modificar recibe un UsuariosEntity que contiene los datos para buscar y modificar un registro de BD.
         */

        public bool Modificar(UsuariosEntity model)
        {
            try
            {
                //primero buscamos el usuario. El usuariosEntity debe tener un ID
                var usuario = Context.Usuarios.FirstOrDefault(f => f.Id.Value == model.Id.Value);
                //una vez obtenido el usuario, cambiamos sus datos menos el ID y el activo, ya que esos no se cambian aquí.
                usuario.Nombre = model.Nombre;
                usuario.NombreUsuario = model.NombreUsuario;
                usuario.Contraseña = model.Contraseña;
                //guardamos los cambios en BD.
                Context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                //si hay algún error, lo guardamos en la variable.
                Error = e;
                return false;
            }
        }
        /*
         * Método iniciar sesión, permite iniciar sesión en el sistema.
         * requiere un usuario y una contraseña.
         */
        public bool IniciarSesion(string usuario, string contraseña)
        {
            //primero, revisamos que el parámetro usuario y contraseña
            if(!string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(contraseña))
            {
                //buscamos si algún registro coincide con el nombre de usuario y contraseña que se proporcionarion, y que sea de los
                //usuarios activos.
                var result = Context.Usuarios.FirstOrDefault(x => x.NombreUsuario==usuario && x.Contraseña==contraseña && x.Activo);
                /*
                 * si encontró algun resultado, se guardará en result.
                 * si no encuentra nada, result será nulo.
                 * si se encontró algún resultado, significa que el usuario y contraseña corresponden a un usuario activo en BD
                 * así que devolvemos true.
                 */
                if (result != null)
                {
                    return true;
                }
                else
                {
                    //si no encontró nada, creamos un error que le diga al usuario que no es un usuario válido.
                    Error = new Exception("Usuario o contraseña inválidos");
                    return false;
                }
            }
            else
            {
                //si usuario o contraseña vienen vacíos, le indicamos que debe de llenar ambos.
                Error = new Exception("Debe ingresar un nombre de usuario y contraseña.");
                return false;
            }
            
        }
    }
}
