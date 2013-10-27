using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class TipoContacto
    {
        public static TipoContacto getById(int id)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var resultado = from tipos in ctx.TipoContacto
                                where tipos.idTipoContacto == id
                                select tipos;
                return resultado.FirstOrDefault<TipoContacto>();
            }
        }
    }
}