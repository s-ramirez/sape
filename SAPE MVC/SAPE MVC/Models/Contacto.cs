//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
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
