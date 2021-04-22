using Datos.Data;
using Datos.Mapper;
using Modelos.Catalogos;
using Modelos.Entities;
using System.Collections.Generic;

namespace Controladores.Catalogos
{
    public class ArticulosCatalogoController
    {
        private readonly ArticulosCatalogo articulosCatalogo;
        public ArticulosCatalogoController()
        {
            //en el constructor inicializamos el usuariosCatalogo para que sea útil. Si no se inicializa, cada
            //que intentemos usar usuariosCatalogo dará error.
            articulosCatalogo = new ArticulosCatalogo();
        }
        /*
         * GenerarEntidad es un método de ayuda, que, en base a parámetos que se envían desde el formulario, creara un usuarioEntity.
         * Recordemos que los método de UsuariosCatalogo utilizan un UsuariosEntity para funcionar, por eso existe este método.
         * nota: el poner ? al final de int, significa que ese int puede o no tener un valor.
         */
        public ArticulosEntity GenerarEntidad(string id, string descripcion, string existencia, string impuesto, string precioVenta)
        {
            
            ArticulosEntity articulo= new ArticulosEntity() { Descripcion=descripcion};
            if (int.TryParse(id, out int nid)) articulo.Id=nid;
            if (int.TryParse(existencia, out int nexistencia)) articulo.Existencia=nexistencia;
            if (int.TryParse(impuesto, out int nimpuesto)) articulo.Impuesto=nimpuesto;
            if (decimal.TryParse(precioVenta, out decimal dprecioVenta)) articulo.PrecioVenta=dprecioVenta;
            return articulo;
        }
        /*
         * El método agregar recibe desde el formulario el nombre, nombre de usuario y contraseña
         * y manda a guardar a BD el nuevo usuario.
         */
        public string Agregar(string descripcion, string existencia, string impuesto, string precioVenta)
        {
            //necesitamos un usuarioEntity para utilizar el método agregar, así que lo generamos.
            //como es agregar y el ID es autoincremental en BD, pasamos un nulo en vez de dar un ID.
            ArticulosEntity articulo = GenerarEntidad(null, descripcion,existencia,impuesto,precioVenta);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (articulosCatalogo.Agregar(articulo))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Articulo agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar articulo:\n" + articulosCatalogo.Error.Message;
            }
        }
        /*
         * Modificar recibe desde el formulario todos los datos que pide el método.
         * manda a actualizar un registro en BD.
         */
        public string Modificar(string id, string descripcion, string existencia, string impuesto, string precioVenta)
        {
            //generamos el usuarioEntity necesario para modificar el registro en BD.
            ArticulosEntity articulo = GenerarEntidad(id, descripcion,existencia,impuesto,precioVenta);
            //Modificar devuelve un booleano, que comparamos en el if.
            if (articulosCatalogo.Modificar(articulo))
            {
                //si todo bien, devolvemos el texto correcto
                return "Articulo modificado correctamente.";
            }
            else
            {
                //si algo falló, devolvemos el error.
                return "Error al modificar articulo:\n" + articulosCatalogo.Error.Message;
            }
        }
        /*
         * Desactiva un usuario de BD.
         * sólo requerimos el ID desde el form para poderlo buscar.
         * en este método, no necesitamos crear un UsuarioEntity.
         */
        public string Desactivar(string id)
        {
            if(int.TryParse(id,out int nid))
            {
                //Eliminar devuelve un booleano, que comparamos en el if.
                if (articulosCatalogo.Eliminar(nid))
                {
                    return "Articulo eliminado correctamente.";
                }
                else
                {
                    //si hay un error, lo devolvemos
                    return "Error al eliminar articulo:\n" + articulosCatalogo.Error.Message;
                }
            }
            else
            {
                return "Error al eliminar articulo:\nId inválido.";
            }
            
        }
        /*
         * ListarUsuarios es el método más complejo de esta clase.
         * devuelve un listado de usuarios activos que obtiene desde BD.
         * también tiene la opción de filtrar si se pasan los parámetros correspondientes.
         */
        public List<ArticulosData> Listar(string id, string descripcion, string existencia, string impuesto, string precioVenta)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(descripcion) || !string.IsNullOrEmpty(existencia) || !string.IsNullOrEmpty(impuesto) || !string.IsNullOrEmpty(precioVenta))
            {
                //si alguno tiene valor, creamos el UsuarioEntity.
                ArticulosEntity articulo = GenerarEntidad(id, descripcion,existencia,impuesto,precioVenta);
                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado UsuariosData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase ArticuloMapper.
                 * pasamos el UsuarioEntity al método listar, y mapeamos el resultado a una lista de ArticuloData.
                 */
                return new ArticulosMapper().MapList(articulosCatalogo.Listar(articulo));
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los usuarios activos.
                return new ArticulosMapper().MapList(articulosCatalogo.Listar());
            }

        }
        /*
         * Buscamos un usuario por su ID y lo devolvemos
         * como la vista no puede interactuar con el modelo, regresamos un UsuariosData a la vista, apoyados
         * de AutoMapper.
         */
        public ArticulosData BuscarPorId(int id)
        {
            return new ArticulosMapper().Map(articulosCatalogo.BuscarPorId(id));
        }

    }
}
