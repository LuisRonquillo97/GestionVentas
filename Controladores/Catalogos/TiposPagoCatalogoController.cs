using Datos.Data;
using Modelos.Catalogos;
using Modelos.Entities;
using Datos.Mapper;
using System.Collections.Generic;

namespace Controladores.Catalogos
{
    public class TiposPagoCatalogoController
    {
        TiposPagoCatalogo tiposPagoCatalogo;
        public TiposPagoCatalogoController()
        {
            tiposPagoCatalogo = new TiposPagoCatalogo();
        }

        public TipoPagoEntity GenerarEntidad(string id, string descripcion)
        {

            TipoPagoEntity articulo = new TipoPagoEntity() { Descripcion = descripcion };
            if (int.TryParse(id, out int nid)) articulo.Id = nid;
            return articulo;
        }

        public string Agregar(string descripcion)
        {
            //necesitamos un usuarioEntity para utilizar el método agregar, así que lo generamos.
            //como es agregar y el ID es autoincremental en BD, pasamos un nulo en vez de dar un ID.
            TipoPagoEntity tipoPago = GenerarEntidad(null, descripcion);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (tiposPagoCatalogo.Agregar(tipoPago))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Tipo de pago agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar Tipo de pago:\n" + tiposPagoCatalogo.Error.Message;
            }
        }
        /*
         * Modificar recibe desde el formulario todos los datos que pide el método.
         * manda a actualizar un registro en BD.
         */
        public string Modificar(string id, string descripcion)
        {
            //generamos el usuarioEntity necesario para modificar el registro en BD.
            TipoPagoEntity tipoPago = GenerarEntidad(id, descripcion);
            //Modificar devuelve un booleano, que comparamos en el if.
            if (tiposPagoCatalogo.Modificar(tipoPago))
            {
                //si todo bien, devolvemos el texto correcto
                return "Tipo de pago modificado correctamente.";
            }
            else
            {
                //si algo falló, devolvemos el error.
                return "Error al modificar Tipo de pago:\n" + tiposPagoCatalogo.Error.Message;
            }
        }
        /*
         * Desactiva un usuario de BD.
         * sólo requerimos el ID desde el form para poderlo buscar.
         * en este método, no necesitamos crear un UsuarioEntity.
         */
        public string Desactivar(string id)
        {
            if (int.TryParse(id, out int nid))
            {
                //Eliminar devuelve un booleano, que comparamos en el if.
                if (tiposPagoCatalogo.Eliminar(nid))
                {
                    return "Tipo de pago eliminado correctamente.";
                }
                else
                {
                    //si hay un error, lo devolvemos
                    return "Error al eliminar Tipo de pago:\n" + tiposPagoCatalogo.Error.Message;
                }
            }
            else
            {
                return "Error al eliminar Tipo de pago:\nId inválido.";
            }

        }
        /*
         * ListarUsuarios es el método más complejo de esta clase.
         * devuelve un listado de usuarios activos que obtiene desde BD.
         * también tiene la opción de filtrar si se pasan los parámetros correspondientes.
         */
        public List<TiposPagoData> Listar(string id, string descripcion)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(descripcion))
            {
                //si alguno tiene valor, creamos el UsuarioEntity.
                TipoPagoEntity tipoPago = GenerarEntidad(id, descripcion);
                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado UsuariosData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase ArticuloMapper.
                 * pasamos el UsuarioEntity al método listar, y mapeamos el resultado a una lista de ArticuloData.
                 */
                return new TiposPagoMapper().MapList(tiposPagoCatalogo.Listar(tipoPago));
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los usuarios activos.
                return new TiposPagoMapper().MapList(tiposPagoCatalogo.Listar());
            }

        }
        /*
         * Buscamos un usuario por su ID y lo devolvemos
         * como la vista no puede interactuar con el modelo, regresamos un UsuariosData a la vista, apoyados
         * de AutoMapper.
         */
        public TiposPagoData BuscarPorId(int id)
        {
            return new TiposPagoMapper().Map(tiposPagoCatalogo.BuscarPorId(id));
        }
    }
}
