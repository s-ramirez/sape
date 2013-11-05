using SAPE_MVC.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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
            ViewBag.Ciudades = database.Ciudad.OrderBy(ciudad => ciudad.Nombre);
            return View();
        }

        [HttpGet]
        public string getEmpresas()
        {
            var empresas = new List<object>();
            SAPEEntities database = new SAPEEntities();

            foreach (Empresa emp in database.Empresa)
            {
                empresas.Add(new
                {
                    value = emp.Nombre
                });
            }
            var serializer = new JavaScriptSerializer();
            return serializer.Serialize(empresas);
        }

        [HttpGet]
        public ActionResult RegistroProfesores()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Profesores = database.Profesor;
            return View();
        }

        [HttpPost]
        public ActionResult RegistroEmpresas(string nombreEmpresa, int ciudad, string nombreContacto, string papellidoContacto, string sapellidoContacto, string telContacto, string emailContacto)
        {
            bool update = true;
            SAPEEntities entities = new SAPEEntities();
            Empresa nuevaEmpresa = Empresa.getByNombre(nombreEmpresa);
            if (nuevaEmpresa == null)
            {
                nuevaEmpresa = new Empresa();
                update = false;
            }
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
            if (!update)
                entities.Empresa.Add(nuevaEmpresa);
            else
            {
                entities.Empresa.Attach(nuevaEmpresa);
                entities.Entry(nuevaEmpresa).State = EntityState.Modified;
            }
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
            CursoXEstudiante nuevoCursoDebe = new CursoXEstudiante();

            //Obtener tipo cntacto "Telefono"
            var result = from tipo in entities.TipoContacto where tipo.Nombre == "Telefono" select tipo;
            TipoContacto tipoContacto = result.FirstOrDefault<TipoContacto>();
            telCandidato.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Obtener tipo contacto "E-mail"
            result = from tipo in entities.TipoContacto where tipo.Nombre == "E-mail" select tipo;
            tipoContacto = result.FirstOrDefault<TipoContacto>();
            emailCandidato.FK_TipoContacto = tipoContacto.idTipoContacto;

            //Crear nueva persona para el estudiante
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
            entities.SaveChanges();

            //Asignar los datos de persona al estudiante
            nuevoCandidato.FK_Persona = nuevaPersona.idPersona;
            nuevoCandidato.Carnet = carnetCand;
            nuevoCandidato.Estado = "C";

            //Agregar estudiante a la DB
            entities.Estudiante.Add(nuevoCandidato);
            entities.SaveChanges();

            //Agregar nuevo curso que se debe
            nuevoCursoDebe.FK_Curso = int.Parse(cursoDebe);

            nuevoCursoDebe.FK_Estudiante = nuevaPersona.idPersona;

            entities.CursoXEstudiante.Add(nuevoCursoDebe);
            entities.SaveChanges();

            return View("FormSent");
        }

        [HttpGet]
        public ActionResult FormularioZonas()
        {
            SAPEEntities database = new SAPEEntities();

            ViewBag.Profesores = database.Profesor;
            ViewBag.Personas = database.Persona;
            ViewBag.Ciudad = database.Ciudad;
            return View();
        }

        [HttpPost]
        public ActionResult FormularioZonas(string nombreProfesor, string zona1, string zona2, string zona3, string zona4, string zona5, string zona6, string comentarios)
        {

            SAPEEntities entities = new SAPEEntities();
            List<string> Zonas = new List<string>(new string[] { zona1, zona2, zona3, zona4, zona5, zona6 });
            for (int counter = 1; counter <= Zonas.Count; counter++)
            {
                if (!Zonas[counter - 1].Equals("-1"))
                {
                    PreferenciaDireccion nuevaPreferencia = new PreferenciaDireccion();
                    nuevaPreferencia.Prioridad = counter;
                    nuevaPreferencia.FK_Profesor = int.Parse(nombreProfesor);
                    nuevaPreferencia.FK_Direccion = int.Parse(Zonas[counter - 1]);
                    nuevaPreferencia.Fecha = DateTime.Now;
                    entities.PreferenciaDireccion.Add(nuevaPreferencia);
                    entities.SaveChanges();
                }
            }
            Profesor profe_actual = Profesor.getById(int.Parse(nombreProfesor));
            profe_actual.Comentario = comentarios;
            entities.Profesor.Attach(profe_actual);
            entities.Entry(profe_actual).State = EntityState.Modified;
            entities.SaveChanges();

            return View("FormSent");
        }

        [HttpGet]
        public ActionResult FormListaNegra()
        {
            SAPEEntities database = new SAPEEntities();

            ViewBag.Profesores = database.Profesor;
            ViewBag.Personas = database.Persona;

            return View();
        }

        [HttpPost]
        public ActionResult FormListaNegra(string carne, int Pref1, int Pref2, int Pref3, int Pref4, int Pref5,
            int NoPref1, int NoPref2, int NoPref3, int NoPref4, int NoPref5,
            string Cmnt1, string Cmnt2, string Cmnt3, string Cmnt4, string Cmnt5)
        {
            int idEstudiante = Estudiante.getByCarne(int.Parse(carne)).idEstudiante;
            SAPEEntities entities = new SAPEEntities();
            List<int> Likes = new List<int>(new int[] { Pref1, Pref2, Pref3, Pref4, Pref5 });
            List<int> Dislikes = new List<int>(new int[] { NoPref1, NoPref2, NoPref3, NoPref4, NoPref5 });
            List<string> Comments = new List<string>(new string[] { Cmnt1, Cmnt2, Cmnt3, Cmnt4, Cmnt5 });

            for (int counter = 1; counter <= 5; counter++)
            {
                if (Likes[counter - 1] > -1)
                {
                    PreferenciaProfesor nuevaPref = new PreferenciaProfesor();
                    nuevaPref.FK_Estudiante = idEstudiante;
                    nuevaPref.FK_Profesor = Likes[counter - 1];
                    nuevaPref.Valor = counter;
                    entities.PreferenciaProfesor.Add(nuevaPref);
                }

                if (Dislikes[counter - 1] > -1)
                {
                    PreferenciaProfesor nuevoDisl = new PreferenciaProfesor();
                    nuevoDisl.FK_Estudiante = idEstudiante;
                    nuevoDisl.FK_Profesor = Dislikes[counter - 1];
                    nuevoDisl.Valor = -1;
                    nuevoDisl.Comentario = Comments[counter - 1];
                    entities.PreferenciaProfesor.Add(nuevoDisl);
                }
                entities.SaveChanges();
            }

            return View("FormSent");
        }

        [HttpGet]
        public JsonResult CheckCarne(int carne)
        {
            using (SAPEEntities ctx = new SAPEEntities())
            {
                var result = from estudiante in ctx.Estudiante
                             where estudiante.Carnet == carne
                             select estudiante;
                try
                {
                    Estudiante res = result.FirstOrDefault<Estudiante>();
                    string json_resp = "true, " + res.Carnet + "," + res.Persona.Apellido1 + " " + res.Persona.Apellido2 + " " + res.Persona.Nombre;
                    return Json(json_resp, JsonRequestBehavior.AllowGet);
                }
                catch
                {
                    return Json("false, null", JsonRequestBehavior.AllowGet);
                }
            }
        }

        [HttpGet]
        public ActionResult FormEmpresasInteresadas()
        {
            SAPEEntities database = new SAPEEntities();
            ViewBag.Empresas = database.Empresa;

            return View();
        }

    }
}
