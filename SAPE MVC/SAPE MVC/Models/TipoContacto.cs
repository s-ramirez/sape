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
    
    public partial class TipoContacto
    {
        public TipoContacto()
        {
            this.Contacto = new HashSet<Contacto>();
        }
    
        public int idTipoContacto { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<Contacto> Contacto { get; set; }
    }
}