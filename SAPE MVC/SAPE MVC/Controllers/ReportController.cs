using SAPE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SAPE_MVC.Controllers
{
    public class ReportController : Controller
    {
        //
        // GET: /Report/

        public ActionResult Index()
        {
            return View();
        }


        //Reporte Candidatos de practica
        [HttpGet]
        public ActionResult ReporteCandidatos()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Candidatos = database.Estudiante.OrderBy(estudiante => estudiante.Carnet);
            ViewBag.Contactos = database.Contacto;
            ViewBag.Cursos = database.Curso;
            ViewBag.CursoDebe = database.CursoXEstudiante;
            return View();
        }


        //Reporte de empresas interesadas
        [HttpGet]
        public ActionResult ReporteInteresadas()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Empresas = database.Empresa;
            return View();
        }


        //Falta el post

        [HttpGet]
        public ActionResult ReporteHistorico()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Empresas = database.Empresa;
            ViewBag.Proyectos = database.Proyecto;
            return View();
        }
    }
}
