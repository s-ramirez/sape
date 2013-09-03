using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data.Entity.Validation;
using SAPE_MVC.Models;
using SAPE_MVC.Security;

namespace SAPE_MVC.Controllers
{
    public class AccountController : Controller
    {
        //
        // GET: /Account/

        public ActionResult Index()
        {
            return View();
        }
        //

        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Models.Usuario pUsuario)
        {
            if (IsValid(pUsuario.Nombre, pUsuario.Contrasena))
            {
                FormsAuthentication.SetAuthCookie(pUsuario.Nombre, false);
                return RedirectToAction("Index", "Main");
            }
            else
            {
                ModelState.AddModelError("", "Datos de usuario incorrectos.");
            }
            return View(pUsuario);
        }



        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.Registro pUsuario)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    using (var database = new SAPE_MVC.Models.SAPEEntities())
                    {
                        SimpleAES encrypter = new SimpleAES();
                        string encryptedPassword = encrypter.EncryptToString(pUsuario.Contrasena);
                        Persona newPersona = database.Persona.Create();
                        Usuario newUsuario = database.Usuario.Create();

                        newPersona.Nombre = pUsuario.Nombre;
                        newPersona.Apellido1 = pUsuario.Apellido1;
                        newPersona.Apellido2 = pUsuario.Apellido2;

                        database.Persona.Add(newPersona);
                        database.SaveChanges();

                        newUsuario.FK_idPersona = newPersona.idPersona;
                        newUsuario.Nombre = pUsuario.Username;
                        newUsuario.Contrasena = encryptedPassword;
                        newUsuario.FK_TipoUsuario = pUsuario.TipoUsuario;
                        database.Usuario.Add(newUsuario);
                        database.SaveChanges();

                        return RedirectToAction("Index", "Main");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Data is not correct");
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:", eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }

            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Main");
        }

        private bool IsValid(string pUsername, string pPassword)
        {
            SimpleAES encryptor = new SimpleAES();
            bool IsValid = false;

            using (var database = new SAPE_MVC.Models.SAPEEntities())
            {
                var user = database.Usuario.FirstOrDefault(usuario => usuario.Nombre == pUsername);
                if (user != null)
                {
                    if (user.Contrasena == encryptor.EncryptToString(pPassword))
                    {
                        IsValid = true;
                    }
                }
            }
            return IsValid;
        }
    }
}
