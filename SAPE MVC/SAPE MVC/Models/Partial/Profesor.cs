using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Profesor
    {
        public static Profesor getById(int id)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_profe = from profe in ctx.Profesor
                                   where profe.idProfesor == id
                                   select profe;
                return res_profe.FirstOrDefault<Profesor>();
            }
        }
    }
}