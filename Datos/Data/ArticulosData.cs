using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Data
{
    public class ArticulosData
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Impuesto { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Existencia { get; set; }
        public bool Activo { get; set; }
    }
}
