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
    
    public partial class Empresa
    {
        public Empresa()
        {
            this.Evaluacion = new HashSet<Evaluacion>();
            this.Proyecto = new HashSet<Proyecto>();
            this.Contacto = new HashSet<Contacto>();
        }
    
        public int idEmpresa { get; set; }
        public string Nombre { get; set; }
        public int FK_Persona { get; set; }
        public int FK_Direccion { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
        public virtual ICollection<Contacto> Contacto { get; set; }
    }
}
