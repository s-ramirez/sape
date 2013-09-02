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
    
    public partial class Estudiante
    {
        public Estudiante()
        {
            this.CursoXEstudiante = new HashSet<CursoXEstudiante>();
            this.Evaluacion = new HashSet<Evaluacion>();
            this.PreferenciaProfesor = new HashSet<PreferenciaProfesor>();
        }
    
        public int idEstudiante { get; set; }
        public int FK_Persona { get; set; }
        public Nullable<int> FK_Proyecto { get; set; }
        public int Carnet { get; set; }
    
        public virtual ICollection<CursoXEstudiante> CursoXEstudiante { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Proyecto Proyecto { get; set; }
        public virtual ICollection<Evaluacion> Evaluacion { get; set; }
        public virtual ICollection<PreferenciaProfesor> PreferenciaProfesor { get; set; }
    }
}
