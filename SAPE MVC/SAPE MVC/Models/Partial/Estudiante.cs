using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Estudiante
    {
        public static Estudiante getByCarne(int carne)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_est = from estudiante in ctx.Estudiante
                              where estudiante.Carnet == carne
                              select estudiante;
                return res_est.FirstOrDefault<Estudiante>();
            }
        }

        public static IList<Estudiante> getPracticantes()
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_practicantes = from estudiante in ctx.Estudiante
                                       where estudiante.Estado.Equals('p')
                                       select estudiante;
                return res_practicantes.ToList<Estudiante>();
            }
        }

        public static IList<Estudiante> getCandidatos()
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_practicantes = from estudiante in ctx.Estudiante
                                       where estudiante.Estado.Equals('c')
                                       select estudiante;
                return res_practicantes.ToList<Estudiante>();
            }
        }
    }
}