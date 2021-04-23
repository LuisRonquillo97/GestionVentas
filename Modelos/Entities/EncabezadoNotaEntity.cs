using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Entities
{
    public class EncabezadoNotaEntity
    {
        public int? Id { get; set; }
        public DateTime? FechaCreado { get; set; }
        public string Comentario { get; set; }
        public int? IdCliente { get; set; }
        public int? IdTipoPago { get; set; }
        public string Status { get; set; }
        public virtual List<DetalleNotaEntity> DetalleNotas { get; set; }
        public virtual ClienteEntity Cliente { get; set; }
        public virtual TipoPagoEntity TipoPago { get; set; }
    }
}
