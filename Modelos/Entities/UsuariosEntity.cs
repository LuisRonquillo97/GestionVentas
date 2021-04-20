using System;
using System.Collections.Generic;
using System.Text;

namespace Modelos.Entities
{
    /*
     * Las entidades es el equivalente en una clase a los campos de base de datos.
     * con esto trabajamos en el sistema, no directamente con la BD.
     */
    public class UsuariosEntity
    {
        public int? Id { get; set; }
        public string Nombre { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public bool Activo { get; set; }
    }
}
