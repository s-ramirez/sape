﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SAPEEntities : DbContext
    {
        public SAPEEntities()
            : base("name=SAPEEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Contacto> Contacto { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<CursoXEstudiante> CursoXEstudiante { get; set; }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<EstadoProyecto> EstadoProyecto { get; set; }
        public DbSet<Estudiante> Estudiante { get; set; }
        public DbSet<Evaluacion> Evaluacion { get; set; }
        public DbSet<Pais> Pais { get; set; }
        public DbSet<Persona> Persona { get; set; }
        public DbSet<PreferenciaDireccion> PreferenciaDireccion { get; set; }
        public DbSet<PreferenciaProfesor> PreferenciaProfesor { get; set; }
        public DbSet<Profesor> Profesor { get; set; }
        public DbSet<Provincia> Provincia { get; set; }
        public DbSet<Proyecto> Proyecto { get; set; }
        public DbSet<TipoContacto> TipoContacto { get; set; }
        public DbSet<TipoEvaluacion> TipoEvaluacion { get; set; }
        public DbSet<TipoUsuario> TipoUsuario { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
    }
}
