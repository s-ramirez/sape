using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Contacto
    {
        public static IList<Contacto> getContactosPersona(int idPersona)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_contactos = from contacto in ctx.Contacto
                                    where contacto.FK_Persona == idPersona
                                    select contacto;
                return res_contactos.ToList<Contacto>();
            }
        }

        public static string getContactoEmpresa(int idEmpresa, string tipo) {
            Empresa empresa = Empresa.getById(idEmpresa);
            IList<Contacto> listaContactos = getContactosPersona(empresa.FK_Persona);
            foreach (Contacto cont in listaContactos)
            {
                if (TipoContacto.getById(cont.FK_TipoContacto).Nombre.Equals(tipo))
                    return cont.Valor;
            }
            return "";
        }
    }
}