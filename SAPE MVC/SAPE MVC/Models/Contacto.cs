//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SAPE_MVC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Contacto
    {
        public int idContacto { get; set; }
        public string Valor { get; set; }
        public int FK_TipoContacto { get; set; }
        public int FK_Persona { get; set; }
    
        public virtual Persona Persona { get; set; }
        public virtual TipoContacto TipoContacto { get; set; }
    }
}
