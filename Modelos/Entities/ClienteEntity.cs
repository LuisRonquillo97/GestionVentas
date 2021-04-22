using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Entities
{
    public class ClienteEntity
    {
        public int? Id { get; set; }
        public string NombreCompleto { get; set; }
        public string Rfc { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
        public virtual List<EncabezadoNotaEntity> EncabezadosNota { get; set; }
    }
}
