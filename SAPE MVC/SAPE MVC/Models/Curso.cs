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
    
    public partial class Curso
    {
        public Curso()
        {
            this.CursoXEstudiante = new HashSet<CursoXEstudiante>();
        }
    
        public int idCurso { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<CursoXEstudiante> CursoXEstudiante { get; set; }
    }
}
