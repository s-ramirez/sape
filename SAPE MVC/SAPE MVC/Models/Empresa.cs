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
    
    public partial class Empresa
    {
        public Empresa()
        {
            this.Evaluacion = new HashSet<Evaluacion>();
            this.Proyecto = new HashSet<Proyecto>();
        }
    
        public int idEmpresa { get; set; }
        public string Nombre { get; set; }
        public int FK_Persona { get; set; }
        public int FK_Direccion { get; set; }
        public int Interesada { get; set; }
        public int Cant_Practicantes { get; set; }
    
        public virtual Ciudad Ciudad { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<Proyecto> Proyecto { get; set; }
    }
}
