using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SAPE_MVC.Models
{
    public partial class Registro
    {
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Username { get; set; }
        public string Contrasena { get; set; }
        public int TipoUsuario { get; set; }
    }
}
