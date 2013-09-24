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
            return View();
        }

    }
}
