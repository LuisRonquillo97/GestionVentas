using AutoMapper;
using Controladores.Data;
using Controladores.Mapper;
using Modelos.Catálogos;
using Modelos.Entities;
using System.Collections.Generic;

namespace Controladores.Catalogos
{
    /*
     * Catálogo de usuarios.
     * Aquí creamos los métodos que se utilizarán en los forms.
     * Recordemos que en MVC, la vista no puede interactuar con el modelo, por eso pasa por aquí.
     */
    public class UsuariosCatalogoController
    {
        //el controlador sí puede interactuar con el modelo, así que implementamos la clase que tiene los métodos
        //de interacción con BD, en este caso, la clase UsuariosCatálogo.
        //lo colocamos aquí para que toda la clase pueda utilizarlo.
        private readonly UsuariosCatalogo usuariosCatalogo;
        public UsuariosCatalogoController()
        {
            //en el constructor inicializamos el usuariosCatalogo para que sea útil. Si no se inicializa, cada
            //que intentemos usar usuariosCatalogo dará error.
            usuariosCatalogo = new UsuariosCatalogo();
        }
        /*
         * GenerarEntidad es un método de ayuda, que, en base a parámetos que se envían desde el formulario, creara un usuarioEntity.
         * Recordemos que los método de UsuariosCatalogo utilizan un UsuariosEntity para funcionar, por eso existe este método.
         * nota: el poner ? al final de int, significa que ese int puede o no tener un valor.
         */
        public UsuariosEntity GenerarEntidad(int? id, string nombre, string nombreUsuario, string contraseña)
        {
            //la notación ?? significa que si id es nulo, lo asigne como 0, y si no, que utilice el valor que tenga.
            //utilizar corchetes después de inicializar un objeto es útil para llenar parámetros rápidamente. tambíén puedes
            //inicializar el objeto y después asignar parámetros uno por uno.
            return new UsuariosEntity() { Id = id ?? 0, Nombre = nombre, NombreUsuario = nombreUsuario, Contraseña = contraseña };
        }
        /*
         * El método agregar recibe desde el formulario el nombre, nombre de usuario y contraseña
         * y manda a guardar a BD el nuevo usuario.
         */
        public string Agregar(string nombre, string nombreUsuario, string contraseña)
        {
            //necesitamos un usuarioEntity para utilizar el método agregar, así que lo generamos.
            //como es agregar y el ID es autoincremental en BD, pasamos un nulo en vez de dar un ID.
            UsuariosEntity Usuario = GenerarEntidad(null, nombre, nombreUsuario, contraseña);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (usuariosCatalogo.Agregar(Usuario))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Usuario agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar usuario:\n" + usuariosCatalogo.Error.Message;
            }
        }
        /*
         * Modificar recibe desde el formulario todos los datos que pide el método.
         * manda a actualizar un registro en BD.
         */
        public string Modificar(int id, string nombre, string nombreUsuario, string contraseña)
        {
            //generamos el usuarioEntity necesario para modificar el registro en BD.
            UsuariosEntity usuario = GenerarEntidad(id, nombre, nombreUsuario, contraseña);
            //Modificar devuelve un booleano, que comparamos en el if.
            if (usuariosCatalogo.Modificar(usuario))
            {
                //si todo bien, devolvemos el texto correcto
                return "Usuario modificado correctamente.";
            }
            else
            {
                //si algo falló, devolvemos el error.
                return "Error al modificar usuario:\n" + usuariosCatalogo.Error.Message;
            }
        }
        /*
         * Desactiva un usuario de BD.
         * sólo requerimos el ID desde el form para poderlo buscar.
         * en este método, no necesitamos crear un UsuarioEntity.
         */
        public string Desactivar(int id)
        {
            //Eliminar devuelve un booleano, que comparamos en el if.
            if (usuariosCatalogo.Eliminar(id))
            {
                return "Usuario eliminado correctamente.";
            }
            else
            {
                //si hay un error, lo devolvemos
                return "Error al eliminar usuario:\n" + usuariosCatalogo.Error.Message;
            }
        }
        /*
         * ListarUsuarios es el método más complejo de esta clase.
         * devuelve un listado de usuarios activos que obtiene desde BD.
         * también tiene la opción de filtrar si se pasan los parámetros correspondientes.
         */
        public List<UsuariosData> ListarUsuarios(int? id, string nombre, string nombreUsuario, string contraseña)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (id.HasValue || !string.IsNullOrEmpty(nombre) || !string.IsNullOrEmpty(nombreUsuario) || !string.IsNullOrEmpty(contraseña))
            {
                //si alguno tiene valor, creamos el UsuarioEntity.
                UsuariosEntity usuario = GenerarEntidad(id, nombre, nombreUsuario, contraseña);
                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado UsuariosData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase UsuarioMapper.
                 * pasamos el UsuarioEntity al método listar, y mapeamos el resultado a una lista de UsuarioData.
                 */
                return new UsuarioMapper().MapList(usuariosCatalogo.Listar(usuario));
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los usuarios activos.
                return new UsuarioMapper().MapList(usuariosCatalogo.Listar());
            }

        }
        /*
         * Buscamos un usuario por su ID y lo devolvemos
         * como la vista no puede interactuar con el modelo, regresamos un UsuariosData a la vista, apoyados
         * de AutoMapper.
         */
        public UsuariosData BuscarPorId(int id)
        {
            return new UsuarioMapper().Map(usuariosCatalogo.BuscarPorId(id));
        }
        /*
         * Método que permite iniciar sesión en el sistema.
         * obtiene del form un usuario y contraseña. si el usuario y contraseña existe en BD, devuelve un string vacío.
         * si ocurre un error, lo devolvemos
         */
        public string IniciarSesion(string usuario, string contraseña)
        {
            //Iniciar sesión devuelve un booleano, así que lo comparamos directo en el IF.
            if (usuariosCatalogo.IniciarSesion(usuario, contraseña))
            {
                //si Iniciar sesión es correcto, no tenemos que devolver ningún mensaje al form, así que mandamos un texto
                //vacío.
                return "";
                
            }
            else
            {
                //si no es correcto, devolvemos el error.
                return "Error al iniciar sesión:\n" + usuariosCatalogo.Error.Message;
            }
        }

    }
}
