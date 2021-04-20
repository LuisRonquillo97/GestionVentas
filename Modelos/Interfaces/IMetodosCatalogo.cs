using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Interfaces
{
    /*
     * La intefaz IMetodosCatalogo contiene los métodos mínimos necesarios por cada tabla en base de datos.
     * T hace referencia a la clase que se utilizará cada que se implemente la interfaz.
     * cuando se implemente y le demos el valor de T, se podría decir que "reemplazará" esas T por el nombre de la clase
     * que le pasemos.
     * por ejemplo, si implemento la interfaz así: IMetodosCatalogo<UsuariosEntity>
     * el método List<T> Listar(T filtros), sería List<UsuariosEntity> Listar(UsuariosEntity filtros)
     */
    public interface IMetodosCatalogo<T>
    {
        public bool Agregar(T model);
        public bool Modificar(T model);
        public bool Eliminar(int Id);
        public T BuscarPorId(int id);
        public List<T> Listar(T filtros);
    }
}
