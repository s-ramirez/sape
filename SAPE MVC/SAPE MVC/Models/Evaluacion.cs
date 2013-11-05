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
    
    public partial class Evaluacion
    {
        public int idEvaluacion { get; set; }
        public decimal Nota { get; set; }
        public int FK_TipoEvaluacion { get; set; }
        public int FK_Estudiante { get; set; }
        public int Evaluador { get; set; }
        public Nullable<int> FK_Empresa { get; set; }
        public Nullable<int> FK_Profesor { get; set; }
    
        public virtual Empresa Empresa { get; set; }
        public virtual Estudiante Estudiante { get; set; }
        public virtual Profesor Profesor { get; set; }
        public virtual TipoEvaluacion TipoEvaluacion { get; set; }
    }
}
