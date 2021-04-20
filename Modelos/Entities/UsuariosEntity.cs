using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Entities
{
    public class UsuariosEntity
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
    }
}
