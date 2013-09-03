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
            ViewBag.Ciudades = database.Provincia.OrderBy(ciudad=> ciudad.Nombre);
            return View();
        }

        public ActionResult RegistroProfesores()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Profesores = database.Profesor.OrderBy(persona => persona.Persona.Apellido1);
            return View();
        }

        [HttpPost]
        public ActionResult RegistroEmpresas(string nombreEmpresa, string practicantes, int cantPracticantes, string ciudad, string nombreContacto, string papellidoContacto, string sapellidoContacto, string telContacto)
        {
            SAPEEntities entities = new SAPEEntities();


            return View();
        }

        public ActionResult RegistroProfesores(string nombreProfesor, string pmrApeProfesor, string sdoApeProfesor, string teleProfesor, string correoProfesor, int cargaMinima, int cargaMaxima)
        {
            SAPEEntities entities = new SAPEEntities();


            return View();
        }
    }
}
