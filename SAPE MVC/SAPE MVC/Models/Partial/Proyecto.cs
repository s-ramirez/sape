using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Proyecto
    {
        public static Proyecto getById(int id)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_proyecto = from proyecto in ctx.Proyecto
                                   where proyecto.idProyecto == id
                                   select proyecto;
                return res_proyecto.FirstOrDefault<Proyecto>();
            }
        }
    }
}