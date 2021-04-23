using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Data
{
    public class DetallesNotaData
    {
        public int? Id { get; set; }
        public int? IdArticulo { get; set; }
        public decimal? PrecioVenta { get; set; }
        public int? Cantidad { get; set; }
        public int? IdEncabezadoNota { get; set; }
        public bool Activo { get; set; }
        public virtual EncabezadosNotaData EncabezadoNota { get; set; }
        public virtual ArticulosData Articulo { get; set; }
    }
}
