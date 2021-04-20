using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Interfaces
{
    public interface IMetodosCatalogo<T>
    {
        public bool Agregar(T model);
        public bool Modificar(T model);
        public bool Eliminar(int Id);
        public T BuscarPorId(int id);
        public List<T> Listar(T filtros);
    }
}
