using System;
using System.Collections.Generic;
using System.Text;

namespace Controladores.Data
{
    //esta clase es igual al UsuarioEntity. ignoré el parámetro Activo porque no lo utilizaremos en la vista.
    public class UsuariosData
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
    }
}
