using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAPE_MVC.Models
{
    public partial class Empresa
    {
        public static Empresa getById(int id)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var res_empresas = from empresas in ctx.Empresa
                                   where empresas.idEmpresa == id
                                   select empresas;
                return res_empresas.FirstOrDefault<Empresa>();
            }
        }

        public static bool Update(int id, string nombre, Persona persona, Ciudad direccion, int interes, int cant_pract)
        {
            using (SAPEEntities ctx = new SAPEEntities()) {
                var result = from emp in ctx.Empresa
                             where emp.idEmpresa == id
                             select emp;
                Empresa empresa = result.FirstOrDefault<Empresa>();
                empresa.Nombre = nombre;
                empresa.FK_Persona = persona.idPersona;
                empresa.FK_Direccion = direccion.idCiudad;
                empresa.Interesada = interes;
                empresa.Cant_Practicantes = cant_pract;
                ctx.SaveChanges();
                return true;
            }
        }
        
        public static bool Update(int id, string nombre, int persona, int direccion, int interes, int cant_pract)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var result = from emp in ctx.Empresa
                             where emp.idEmpresa == id
                             select emp;
                Empresa empresa = result.FirstOrDefault<Empresa>();
                empresa.Nombre = nombre;
                empresa.FK_Persona = persona;
                empresa.FK_Direccion = direccion;
                empresa.Interesada = interes;
                empresa.Cant_Practicantes = cant_pract;
                ctx.SaveChanges();
                return true;
            }
        }
    }
}