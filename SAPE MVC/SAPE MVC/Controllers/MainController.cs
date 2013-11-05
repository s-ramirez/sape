using SAPE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace SAPE_MVC.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Main/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegistroEmpresas()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Empresas = database.Empresa;
            ViewBag.Contactos = database.Contacto;
            return View();
        }

        [HttpGet]
        public ActionResult GestionarPracticantes()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Practicantes = Estudiante.getPracticantes();
            return View();
        }


        [HttpGet]
        public ActionResult Calificaciones()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Estudiantes = database.Estudiante;
            return View();
        }

        [HttpPost]
        public ActionResult EnviarCorreo(string emailList, string mailSubject, string mailContent)
        {
            if (String.IsNullOrEmpty(emailList))
            {
                TempData["Message"] = "No se ha seleccionado ninguna empresa para enviar correo";
                return RedirectToAction("RegistroEmpresas");
            }

            try
            {

                MailMessage mail = new MailMessage("sape.tec@gmail.com", emailList, mailSubject, mailContent);

                System.Net.NetworkCredential gmailCreds = new System.Net.NetworkCredential("sape.tec@gmail.com", "sapetec2013", "");
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = gmailCreds;


                client.Send(mail);
            }
            catch (Exception)
            {
                TempData["Message"] = "Hubo un error al enviar los correos deseados";
                return RedirectToAction("RegistroEmpresas");
            }

            TempData["Message"] = "Los correos han sido enviados con exito";

            return RedirectToAction("RegistroEmpresas");
        }

    }
}
