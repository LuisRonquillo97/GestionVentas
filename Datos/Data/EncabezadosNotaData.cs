using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Data
{
    public class EncabezadosNotaData
    {
        public int? Id { get; set; }
        public DateTime FechaCreado { get; set; }
        public string Comentario { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoPago { get; set; }
        public string Status { get; set; }
        public virtual List<DetallesNotaData> DetalleNotas { get; set; }
        public virtual ClientesData Cliente { get; set; }
        public virtual TiposPagoData TipoPago { get; set; }
    }
}
