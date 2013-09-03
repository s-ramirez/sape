using SAPE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPE_MVC.Controllers
{
    public class FormController : Controller
    {
        //
        // GET: /Form/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegistroEmpresas()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Ciudades = database.Ciudad.OrderBy(ciudad=> ciudad.Nombre);
            return View();
        }

        [HttpPost]
        public ActionResult RegistroEmpresas(string nombreEmpresa, string practicantes, int cantPracticantes, int ciudad, string nombreContacto, string papellidoContacto, string sapellidoContacto, string telContacto, string  emailContacto)
        {
            SAPEEntities entities = new SAPEEntities();
            Empresa nuevaEmpresa = new Empresa();
            Persona nuevaPersona = new Persona();
            Contacto tel = new Contacto();
            Contacto email = new Contacto();

            //Obtener tipo contacto "Telefono"
            var result = from tipo in entities.TipoContacto where tipo.Nombre == "Telefono" select tipo;
            TipoContacto tipoContacto = result.FirstOrDefault<TipoContacto>();
            tel.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Obtener tipo contacto "E-mail"
            result = from tipo in entities.TipoContacto where tipo.Nombre == "E-mail" select tipo;
            tipoContacto = result.FirstOrDefault<TipoContacto>();
            email.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Crear nueva persona para el contacto
            nuevaPersona.Nombre = nombreContacto;
            nuevaPersona.Apellido1 = papellidoContacto;
            nuevaPersona.Apellido2 = sapellidoContacto;
            
            //Agregarla a la DB para obtener su id
            entities.Persona.Add(nuevaPersona);
            entities.SaveChanges();

            //Asignar los contactos a la nueva persona
            email.FK_Persona = nuevaPersona.idPersona;
            tel.FK_Persona = nuevaPersona.idPersona;

            //Agregar los contactos a la base
            tel.Valor = telContacto;
            email.Valor = emailContacto;
            entities.Contacto.Add(tel);
            entities.Contacto.Add(email);

            //Crear empresa
            nuevaEmpresa.Nombre = nombreEmpresa;
            nuevaEmpresa.FK_Direccion = ciudad;
            nuevaEmpresa.FK_Persona = nuevaPersona.idPersona;

            //Agregar empresa a la DB
            entities.Empresa.Add(nuevaEmpresa);
            entities.SaveChanges();

            return View("FormSent");
        }
    }
}
