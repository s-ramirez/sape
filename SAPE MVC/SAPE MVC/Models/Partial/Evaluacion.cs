using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Evaluacion
    {
        public static Evaluacion get(int idTipo, int idEst)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_cal = from eval in ctx.Evaluacion
                              where eval.FK_TipoEvaluacion == idTipo && eval.FK_Estudiante == idEst
                              select eval;
                return res_cal.FirstOrDefault<Evaluacion>();
            }
        }
    }
}