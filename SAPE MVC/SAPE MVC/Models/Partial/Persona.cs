using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Persona
    {
        public static Persona getById(int id)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_personas = from personas in ctx.Persona
                                   where personas.idPersona == id
                                   select personas;
                return res_personas.FirstOrDefault<Persona>();
            }
        }
    }
}