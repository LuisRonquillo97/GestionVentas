using System;
using System.Collections.Generic;
using System.Text;

namespace Datos.Data
{
    public class DgvEncabezadoNota
    {
        public DateTime FechaCreado { get; set; }
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public string Cliente { get; set; }
        public string Status { get; set; }
        public int IdTipoPago { get; set; }
        public string TipoPago { get; set; }
        public string Comentario { get; set; }
    }
}
