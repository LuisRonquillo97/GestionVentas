using Datos.Data;
using Datos.Mapper;
using Modelos.Catalogos;
using Modelos.Entities;
using System;
using System.Collections.Generic;

namespace Controladores.Catalogos
{
    public class EncabezadosNotaCatalogoController
    {
        private readonly EncabezadoNotaCatalogo encabezadosCatalogo;
        public EncabezadosNotaCatalogoController()
        {
            //en el constructor inicializamos el usuariosCatalogo para que sea útil. Si no se inicializa, cada
            //que intentemos usar usuariosCatalogo dará error.
            encabezadosCatalogo = new EncabezadoNotaCatalogo();
        }
        /*
         * GenerarEntidad es un método de ayuda, que, en base a parámetos que se envían desde el formulario, creara un usuarioEntity.
         * Recordemos que los método de UsuariosCatalogo utilizan un UsuariosEntity para funcionar, por eso existe este método.
         * nota: el poner ? al final de int, significa que ese int puede o no tener un valor.
         */
        public EncabezadoNotaEntity GenerarEntidad(string id, string comentario, DateTime? fechaCreado, string idCliente, string idTipoPago, string status)
        {

            EncabezadoNotaEntity encabezado = new EncabezadoNotaEntity() { Comentario = comentario, Status = status };
            if (int.TryParse(id, out int nid)) encabezado.Id = nid;
            if (fechaCreado.HasValue) encabezado.FechaCreado = fechaCreado.Value;
            if (int.TryParse(idCliente, out int nidCliente)) encabezado.IdCliente = nidCliente;
            if (int.TryParse(idTipoPago, out int nidTipoPago)) encabezado.IdTipoPago = nidTipoPago;
            return encabezado;
        }
        /*
         * El método agregar recibe desde el formulario el nombre, nombre de usuario y contraseña
         * y manda a guardar a BD el nuevo usuario.
         */
        public string Agregar(string comentario, DateTime fechaCreado, string idCliente, string idTipoPago, string status)
        {
            //necesitamos un usuarioEntity para utilizar el método agregar, así que lo generamos.
            //como es agregar y el ID es autoincremental en BD, pasamos un nulo en vez de dar un ID.
            EncabezadoNotaEntity articulo = GenerarEntidad(null, comentario, fechaCreado, idCliente, idTipoPago, status);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (encabezadosCatalogo.Agregar(articulo))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Encabezado de nota agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar Encabezado de nota :\n" + encabezadosCatalogo.Error.Message;
            }
        }
        public string AgregarEntidad(EncabezadoNotaEntity encabezado)
        {

            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (encabezadosCatalogo.Agregar(encabezado))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Encabezado de nota agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar Encabezado de nota :\n" + encabezadosCatalogo.Error.Message;
            }
        }
        public string AgregarEntidad(EncabezadosNotaData encabezadoData, List<DgvDetalleNota> detallesNotasDgv)
        {
            EncabezadoNotaEntity encabezado = new EncabezadosNotaMapper().Map(encabezadoData);
            encabezado.DetalleNotas = new DetallesNotaMapper().MapList(detallesNotasDgv);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (encabezadosCatalogo.Agregar(encabezado))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Encabezado de nota agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar Encabezado de nota :\n" + encabezadosCatalogo.Error.Message;
            }
        }
        /*
         * Modificar recibe desde el formulario todos los datos que pide el método.
         * manda a actualizar un registro en BD.
         */
        public string Modificar(string id, string comentario, DateTime fechaCreado, string idCliente, string idTipoPago, string status)
        {
            //generamos el usuarioEntity necesario para modificar el registro en BD.
            EncabezadoNotaEntity articulo = GenerarEntidad(id, comentario, fechaCreado, idCliente, idTipoPago, status);
            //Modificar devuelve un booleano, que comparamos en el if.
            if (encabezadosCatalogo.Modificar(articulo))
            {
                //si todo bien, devolvemos el texto correcto
                return "Encabezado de nota modificado correctamente.";
            }
            else
            {
                //si algo falló, devolvemos el error.
                return "Error al modificar Encabezado de nota :\n" + encabezadosCatalogo.Error.Message;
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
                if (encabezadosCatalogo.Eliminar(nid))
                {
                    return "Encabezado de nota eliminado correctamente.";
                }
                else
                {
                    //si hay un error, lo devolvemos
                    return "Error al eliminar Encabezado de nota:\n" + encabezadosCatalogo.Error.Message;
                }
            }
            else
            {
                return "Error al eliminar Encabezado de nota:\nId inválido.";
            }

        }
        /*
         * ListarUsuarios es el método más complejo de esta clase.
         * devuelve un listado de usuarios activos que obtiene desde BD.
         * también tiene la opción de filtrar si se pasan los parámetros correspondientes.
         */
        public List<EncabezadoNotaEntity> Listar(string id, string comentario, DateTime? fechaCreado, string idCliente, string idTipoPago, string status)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(comentario) || !string.IsNullOrEmpty(idCliente) || !string.IsNullOrEmpty(idTipoPago) || !string.IsNullOrEmpty(status) || fechaCreado.HasValue)
            {
                EncabezadoNotaEntity encabezado = GenerarEntidad(id, comentario, fechaCreado.Value, idCliente, idTipoPago, status);
                //si alguno tiene valor, creamos el UsuarioEntity.

                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado UsuariosData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase ArticuloMapper.
                 * pasamos el UsuarioEntity al método listar, y mapeamos el resultado a una lista de ArticuloData.
                 */
                return encabezadosCatalogo.Listar(encabezado);
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los usuarios activos.
                return encabezadosCatalogo.Listar();
            }

        }
        /*
         * Buscamos un usuario por su ID y lo devolvemos
         * como la vista no puede interactuar con el modelo, regresamos un UsuariosData a la vista, apoyados
         * de AutoMapper.
         */
        public List<DgvEncabezadoNota> ListarDgvEncabezadoNota(string id, string comentario, DateTime? fechaCreado, string idCliente, string idTipoPago, string status)
        {
            return new EncabezadosNotaMapper().MapListDatagridEncabezado(Listar(id, comentario, fechaCreado, idCliente, idTipoPago, status));
        }

        public List<EncabezadosNotaData> ListarEncabezadoNotaData(string id, string comentario, DateTime? fechaCreado, string idCliente, string idTipoPago, string status)
        {
            return new EncabezadosNotaMapper().MapList(Listar(id, comentario, fechaCreado, idCliente, idTipoPago, status));
        }
        public DgvEncabezadoNota BuscarPorId(int id)
        {
            return new EncabezadosNotaMapper().MapDatagridEncabezado(encabezadosCatalogo.BuscarPorId(id));
        }
    }
}
