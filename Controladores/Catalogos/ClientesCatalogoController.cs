using Datos.Data;
using Datos.Mapper;
using Modelos.Catalogos;
using Modelos.Entities;
using System.Collections.Generic;

namespace Controladores.Catalogos
{
    public class ClientesCatalogoController
    {
        private readonly ClientesCatalogo clientesCatalogo;
        public ClientesCatalogoController()
        {
            //en el constructor inicializamos el clientesCatalogo para que sea útil. Si no se inicializa, cada
            //que intentemos usar clientesCatalogo dará error.
            clientesCatalogo = new ClientesCatalogo();
        }
        /*
         * GenerarEntidad es un método de ayuda, que, en base a parámetos que se envían desde el formulario, creara un clienteEntity.
         * Recordemos que los método de ClientesCatalogo utilizan un ClientesEntity para funcionar, por eso existe este método.
         * nota: el poner ? al final de int, significa que ese int puede o no tener un valor.
         */
        public ClienteEntity GenerarEntidad(string id, string direccion, string nombreCompleto, string rfc)
        {

            ClienteEntity cliente = new ClienteEntity() { Direccion = direccion,NombreCompleto=nombreCompleto,Rfc=rfc };
            if (int.TryParse(id, out int nid)) cliente.Id = nid;
            return cliente;
        }
        /*
         * El método agregar recibe desde el formulario el nombre, nombre de cliente y contraseña
         * y manda a guardar a BD el nuevo cliente.
         */
        public string Agregar(string direccion, string nombreCompleto, string rfc)
        {
            //necesitamos un clienteEntity para utilizar el método agregar, así que lo generamos.
            //como es agregar y el ID es autoincremental en BD, pasamos un nulo en vez de dar un ID.
            ClienteEntity cliente = GenerarEntidad(null, direccion, nombreCompleto, rfc);
            //el método agregar devuelve un booleano, que utilizamos para comparar directamente en el if.
            if (clientesCatalogo.Agregar(cliente))
            {
                //si es true, devolvemos el mensaje de que se agregó correctamente
                return "Cliente agregado correctamente.";
            }
            else
            {
                //si es false, devolvemos el error que se generó.
                //\n sirve para hacer un salto de línea.
                return "Error al agregar cliente:\n" + clientesCatalogo.Error.Message;
            }
        }
        /*
         * Modificar recibe desde el formulario todos los datos que pide el método.
         * manda a actualizar un registro en BD.
         */
        public string Modificar(string id, string direccion, string nombreCompleto, string rfc)
        {
            //generamos el clienteEntity necesario para modificar el registro en BD.
            ClienteEntity cliente = GenerarEntidad(id, direccion, nombreCompleto, rfc);
            //Modificar devuelve un booleano, que comparamos en el if.
            if (clientesCatalogo.Modificar(cliente))
            {
                //si todo bien, devolvemos el texto correcto
                return "Cliente modificado correctamente.";
            }
            else
            {
                //si algo falló, devolvemos el error.
                return "Error al modificar cliente:\n" + clientesCatalogo.Error.Message;
            }
        }
        /*
         * Desactiva un cliente de BD.
         * sólo requerimos el ID desde el form para poderlo buscar.
         * en este método, no necesitamos crear un ClienteEntity.
         */
        public string Desactivar(string id)
        {
            if (int.TryParse(id, out int nid))
            {
                //Eliminar devuelve un booleano, que comparamos en el if.
                if (clientesCatalogo.Eliminar(nid))
                {
                    return "Cliente eliminado correctamente.";
                }
                else
                {
                    //si hay un error, lo devolvemos
                    return "Error al eliminar cliente:\n" + clientesCatalogo.Error.Message;
                }
            }
            else
            {
                return "Error al eliminar cliente:\nId inválido.";
            }

        }
        /*
         * ListarClientes es el método más complejo de esta clase.
         * devuelve un listado de clientes activos que obtiene desde BD.
         * también tiene la opción de filtrar si se pasan los parámetros correspondientes.
         */
        public List<ClientesData> Listar(string id, string direccion, string nombreCompleto, string rfc)
        {
            //primero revisamos que al menos uno de todos los parámetros que podemos obtener desde el form tenga algún dato
            //para saber si debemos filtrar algo.
            if (!string.IsNullOrEmpty(id) || !string.IsNullOrEmpty(direccion) || !string.IsNullOrEmpty(nombreCompleto) || !string.IsNullOrEmpty(rfc))
            {
                //si alguno tiene valor, creamos el ClienteEntity.
                ClienteEntity cliente = GenerarEntidad(id, direccion, nombreCompleto, rfc);
                /*
                 * recordemos que en MVC, el modelo, que es de donde devolvemos los datos, no puede interactual con la vista
                 * que es el form.
                 * Utilizamos una clase que tiene los mismos parámetros que la entidad de BD, que generamos desde aquí en controladores
                 * llamado ClientesData, que sí puede llegar a la capa de vista(el form).
                 * nos apoyamos con una herramienta llamada automapper, que pasa los valor de un tipo de objeto A, a un tipo de objeto B.
                 * La explicación de cómo funciona estará en la clase ClienteMapper.
                 * pasamos el ClienteEntity al método listar, y mapeamos el resultado a una lista de ClienteData.
                 */
                return new ClientesMapper().MapList(clientesCatalogo.Listar(cliente));
            }
            else
            {
                //si no se tienen datos para filtrar, obtenemos la lista de los clientes activos.
                return new ClientesMapper().MapList(clientesCatalogo.Listar());
            }

        }
        /*
         * Buscamos un cliente por su ID y lo devolvemos
         * como la vista no puede interactuar con el modelo, regresamos un ClientesData a la vista, apoyados
         * de AutoMapper.
         */
        public ClientesData BuscarPorId(int id)
        {
            return new ClientesMapper().Map(clientesCatalogo.BuscarPorId(id));
        }
    }
}
