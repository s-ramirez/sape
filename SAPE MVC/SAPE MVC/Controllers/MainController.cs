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

        protected override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);
            // check if user is authenticated before executing an action and redirect if not
            if (Session["CurrentUser"] == null)
            {
                context.Result = new RedirectResult("/Account/LogIn");
            }
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
            ViewBag.Tipos = database.TipoEvaluacion;
            ViewBag.Estudiantes = database.Estudiante;
            return View();

        }

        [HttpGet]
        public JsonResult SaveCalifs(string id, string value)
        {
            SAPEEntities entities = new SAPEEntities();
            String idEstudiante = id.Split(',')[0];
            String idEvaluacion = id.Split(',')[1];
            Evaluacion eval;
            try
            {
                eval = Evaluacion.get(int.Parse(idEstudiante), int.Parse(idEvaluacion));
                eval.Nota = decimal.Parse(value);
                entities.Evaluacion.Attach(eval);
                entities.Entry(eval).State = System.Data.EntityState.Modified;
                entities.SaveChanges();
            }
            catch
            {
                eval = new Evaluacion();
                eval.Nota = decimal.Parse(value);
                eval.FK_TipoEvaluacion = int.Parse(idEvaluacion);
                eval.FK_Estudiante = int.Parse(idEstudiante);
                entities.Evaluacion.Add(eval);
                entities.SaveChanges();
            }

            string json_resp = "true";
            return Json(json_resp, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public ActionResult login()
        {
            return RedirectToAction("LogIn", "Account");
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
