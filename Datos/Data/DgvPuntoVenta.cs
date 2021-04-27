using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Data
{
    public class DgvPuntoVenta
    {
        public int IdArticulo { get; set; }
        public string Articulo { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Cantidad { get; set; }
        public decimal Total { get; set; }
    }
}
