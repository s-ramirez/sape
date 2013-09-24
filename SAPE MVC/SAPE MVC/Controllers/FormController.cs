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

        [HttpGet]
        public ActionResult RegistroProfesores()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Profesores = database.Profesor;
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

        [HttpPost]
        public ActionResult RegistroProfesores(string nombreProfesor, string pmrApeProf, string sdoApeProf, string teleProfe, string correoProfe)
        {
            SAPEEntities entities = new SAPEEntities();
            Profesor nuevoProfesor = new Profesor();
            Persona nuevaPersona = new Persona();
            Contacto telProf = new Contacto();
            Contacto emailProf = new Contacto();

            //Obtener tipo cntacto "Telefono"
            var result = from tipo in entities.TipoContacto where tipo.Nombre == "Telefono" select tipo;
            TipoContacto tipoContacto = result.FirstOrDefault<TipoContacto>();
            telProf.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Obtener tipo contacto "E-mail"
            result = from tipo in entities.TipoContacto where tipo.Nombre == "E-mail" select tipo;
            tipoContacto = result.FirstOrDefault<TipoContacto>();
            emailProf.FK_TipoContacto = tipoContacto.idTipoContacto;
            
            //Crear nueva persona para el profesor
            nuevaPersona.Nombre = nombreProfesor;
            nuevaPersona.Apellido1 = pmrApeProf;
            nuevaPersona.Apellido2 = sdoApeProf;

            //Agregarla a la DB para obtener su id
            entities.Persona.Add(nuevaPersona);
            entities.SaveChanges();

            //Asignar los contactos a la nuea persona
            emailProf.FK_Persona = nuevaPersona.idPersona;
            telProf.FK_Persona = nuevaPersona.idPersona;

            //Agregar los contactos a la base
            telProf.Valor = teleProfe;
            emailProf.Valor = correoProfe;
            entities.Contacto.Add(telProf);
            entities.Contacto.Add(emailProf);

            //Asignar los datos de persona al profesor
            nuevoProfesor.FK_Persona = nuevaPersona.idPersona;
            nuevoProfesor.Asesora = 0;
            nuevoProfesor.CargaMinima = 0;
            nuevoProfesor.CargaMaxima = 0;
            

            //Agregar profesor a la DB
            entities.Profesor.Add(nuevoProfesor);
            entities.SaveChanges();
            
            return View("FormSent");
        }

        [HttpGet]
        public ActionResult RegistroProfAsesor()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Profesores = database.Profesor;
            return View();
        }

        [HttpPost]
        public ActionResult RegistroProfAsesor(string selectProfesores, string respAsesor)
        {
            SAPEEntities entities = new SAPEEntities();
            Profesor actualizaProfesor = new Profesor();

            return View();
        }

        [HttpGet]
        public ActionResult RegistroCandidatos()
        {
            SAPEEntities database = new SAPEEntities();

            ViewBag.Profesores = database.Profesor;
            ViewBag.Curso = database.Curso.OrderBy(curso => curso.idCurso);

            return View();
        }

        [HttpPost]
        public ActionResult RegistroCandidatos(string nombreCand, string prmApellidoCand, string sdoApellidoCand, int carnetCand, string telCand, string correoCand, string cursoDebe)
        {
            SAPEEntities entities = new SAPEEntities();
            Estudiante nuevoCandidato = new Estudiante();
            Persona nuevaPersona = new Persona();
            Contacto telCandidato = new Contacto();
            Contacto emailCandidato = new Contacto();

            //Obtener tipo cntacto "Telefono"
            var result = from tipo in entities.TipoContacto where tipo.Nombre == "Telefono" select tipo;
            TipoContacto tipoContacto = result.FirstOrDefault<TipoContacto>();
            telCandidato.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Obtener tipo contacto "E-mail"
            result = from tipo in entities.TipoContacto where tipo.Nombre == "E-mail" select tipo;
            tipoContacto = result.FirstOrDefault<TipoContacto>();
            emailCandidato.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Crear nueva persona para el profesor
            nuevaPersona.Nombre = nombreCand;
            nuevaPersona.Apellido1 = prmApellidoCand;
            nuevaPersona.Apellido2 = sdoApellidoCand;

            //Agregarla a la DB para obtener su id
            entities.Persona.Add(nuevaPersona);
            entities.SaveChanges();

            //Asignar clos contactos a la nueva persona
            emailCandidato.FK_Persona = nuevaPersona.idPersona;
            telCandidato.FK_Persona = nuevaPersona.idPersona;

            //Agregar los contactos a la base
            telCandidato.Valor = telCand;
            emailCandidato.Valor = correoCand;
            entities.Contacto.Add(telCandidato);
            entities.Contacto.Add(emailCandidato);

            //Asignar los datos de persona al estudiante
            nuevoCandidato.FK_Persona = nuevaPersona.idPersona;
            nuevoCandidato.Carnet = carnetCand;

            //Agregar profesor a la DB
            entities.Estudiante.Add(nuevoCandidato);
            entities.SaveChanges();
            
            return View("FormSent");
        }
    }
}
