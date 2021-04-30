using Datos.Data;
using Datos.Mapper;
using Modelos.Catalogos;
using Modelos.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Controladores.Catalogos
{
    public class DetallesNotaCatalogoController
    {
        private readonly DetalleNotaCatalogo detallesCatalogo;
        public DetallesNotaCatalogoController()
        {
            //en el constructor inicializamos el usuariosCatalogo para que sea útil. Si no se inicializa, cada
            //que intentemos usar usuariosCatalogo dará error.
            detallesCatalogo = new DetalleNotaCatalogo();
        }
        /*
         * GenerarEntidad es un método de ayuda, que, en base a parámetos que se envían desde el formulario, creara un usuarioEntity.
         * Recordemos que los método de UsuariosCatalogo utilizan un UsuariosEntity para funcionar, por eso existe este método.
         * nota: el poner ? al final de int, significa que ese int puede o no tener un valor.
         */
        public DetalleNotaEntity GenerarEntidad(string id, string cantidad, string idArticulo, string idEncabezadoNota, string precioVenta)
        {

            DetalleNotaEntity detalleNota = new DetalleNotaEntity();
            if (int.TryParse(id, out int nid)) detalleNota.Id = nid;
            if (int.TryParse(cantidad, out int nCantidad)) detalleNota.Cantidad = nCantidad;
            if (int.TryParse(idArticulo, out int nidArticulo)) detalleNota.IdArticulo= nidArticulo;
            if (int.TryParse(idEncabezadoNota, out int nidEncabezadoNota)) detalleNota.IdEncabezadoNota = nidEncabezadoNota;
            if (decimal.TryParse(precioVenta, out decimal dprecioVenta)) detalleNota.PrecioVenta = dprecioVenta;
            return detalleNota;
        }
        /*
         * El método agregar recibe desde el formulario el nombre, nombre de usuario y contraseña
         * y manda a guardar a BD el nuevo usuario.
         */
        public string Agregar(string cantidad, string idArticulo, string idEncabezadoNota, string precioVenta)
        {
            //necesitamos un usuarioEntity para utilizar el método agregar, así que lo generamos.
            //como es agregar y el ID es autoincremental en BD, pasamos un nulo en vez de dar un ID.
            DetalleNotaEntity detalleNota = GenerarEntidad(null, cantidad, idArticulo, idEncabezadoNota, precioVenta);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (detallesCatalogo.Agregar(detalleNota))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Detalle de nota agregada correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar detalle de nota:\n" + detallesCatalogo.Error.Message;
            }
        }
        /*
         * Modificar recibe desde el formulario todos los datos que pide el método.
         * manda a actualizar un registro en BD.
         */
        public string Modificar(string id, string cantidad, string idArticulo, string idEncabezadoNota, string precioVenta)
        {
            //generamos el usuarioEntity necesario para modificar el registro en BD.
            DetalleNotaEntity detalleNota= GenerarEntidad(id, cantidad, idArticulo, idEncabezadoNota, precioVenta);
            //Modificar devuelve un booleano, que comparamos en el if.
            if (detallesCatalogo.Modificar(detalleNota))
            {
                //si todo bien, devolvemos el texto correcto
                return "Detalle de nota modificada correctamente.";
            }
            else
            {
                //si algo falló, devolvemos el error.
                return "Error al modificar detalle de nota:\n" + detallesCatalogo.Error.Message;
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
                if (detallesCatalogo.Eliminar(nid))
                {
                    return "Detalle de nota eliminada correctamente.";
                }
                else
                {
                    //si hay un error, lo devolvemos
                    return "Error al eliminar detalle de nota:\n" + detallesCatalogo.Error.Message;
                }
            }
            else
            {
                return "Error al eliminar Detalle de nota:\nId inválido.";
            }

        }
        /*
         * ListarUsuarios es el método más complejo de esta clase.
         * devuelve un listado de usuarios activos que obtiene desde BD.
         * también tiene la opción de filtrar si se pasan los parámetros correspondientes.
         */
        public List<DetallesNotaData> Listar(string id, string cantidad, string idArticulo, string idEncabezadoNota, string precioVenta)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(cantidad) || !string.IsNullOrEmpty(idArticulo) || !string.IsNullOrEmpty(idEncabezadoNota) || !string.IsNullOrEmpty(precioVenta))
            {
                //si alguno tiene valor, creamos el UsuarioEntity.
                DetalleNotaEntity detalleNota= GenerarEntidad(id, cantidad, idArticulo, idEncabezadoNota, precioVenta);
                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado UsuariosData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase ArticuloMapper.
                 * pasamos el UsuarioEntity al método listar, y mapeamos el resultado a una lista de ArticuloData.
                 */
                return new DetallesNotaMapper().MapList(detallesCatalogo.Listar(detalleNota));
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los usuarios activos.
                return new DetallesNotaMapper().MapList(detallesCatalogo.Listar());
            }

        }
        public List<DgvDetalleNota> ListarDgv(string id, string cantidad, string idArticulo, string idEncabezadoNota, string precioVenta)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(cantidad) || !string.IsNullOrEmpty(idArticulo) || !string.IsNullOrEmpty(idEncabezadoNota) || !string.IsNullOrEmpty(precioVenta))
            {
                //si alguno tiene valor, creamos el UsuarioEntity.
                DetalleNotaEntity detalleNota = GenerarEntidad(id, cantidad, idArticulo, idEncabezadoNota, precioVenta);
                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado UsuariosData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase ArticuloMapper.
                 * pasamos el UsuarioEntity al método listar, y mapeamos el resultado a una lista de ArticuloData.
                 */
                return new DetallesNotaMapper().MapDgvVentas(detallesCatalogo.Listar(detalleNota));
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los usuarios activos.
                return new DetallesNotaMapper().MapDgvVentas(detallesCatalogo.Listar());
            }

        }
        public List<DetallesNotaData> ListarDetallePorEncabezado(string idEncabezado)
        {
            List<DetallesNotaData> detalles = new List<DetallesNotaData>();
            if (int.TryParse(idEncabezado, out _))
            {
                detalles = Listar("", "", "", idEncabezado, "");
            }
            return detalles;
        }
        public decimal TotalDetalle(string idEncabezado)
        {
            decimal total = 0;
            foreach (DetallesNotaData detalle in ListarDetallePorEncabezado(idEncabezado))
            {
                total += detalle.PrecioVenta.Value;
            }
            return total;
        }
        /*
         * Buscamos un usuario por su ID y lo devolvemos
         * como la vista no puede interactuar con el modelo, regresamos un UsuariosData a la vista, apoyados
         * de AutoMapper.
         */
        public DetallesNotaData BuscarPorId(int id)
        {
            return new DetallesNotaMapper().Map(detallesCatalogo.BuscarPorId(id));
        }
    }
}
