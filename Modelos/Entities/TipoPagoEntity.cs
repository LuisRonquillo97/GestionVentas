using System.Collections.Generic;

namespace Modelos.Entities
{
    public class TipoPagoEntity
    {
        public int? Id { get; set; }
        public string Descripcion { get; set; }
        public bool Activo { get; set; }
        public virtual List<EncabezadoNotaEntity> EncabezadosNota { get; set; }
    }
}
