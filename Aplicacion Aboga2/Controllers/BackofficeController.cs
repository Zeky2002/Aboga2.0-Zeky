using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacion_Aboga2.Models;
namespace Aplicacion_Aboga2.Controllers
{
    public class BackofficeController : Controller
    {

        public BackofficeController() { }

        // GET: Backoffice
        public ActionResult Menu()
        {
            return View();
        }
        /*public ActionResult ABMContactos(Contactos cts)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }
        public ActionResult InsertarContactos(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult FormContactos(string Accion, int IdCts)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }*/

        public ActionResult ABMExpedientes(Expediente ex)
        {
            ViewBag.Expedientes = BD.TraerExpedientes();
            return View();
        }
        public ActionResult ABMContactos(Contacto contacto)
        {
            ViewBag.Contactos = BD.TraerContactos();
            return View();
        }

        public ActionResult ABMEventos(Evento Eve, int IdEx, int IdCont)
        {
            ViewBag.IdContactos = IdCont;
            ViewBag.IdExpediente = IdEx;
            ViewBag.Eventos = BD.TraerEventos();
            return View();
        }


        public ActionResult ABMExpedienteFojas(ExpedienteFojas Expf, int IdEx)
        {
            ViewBag.IdExpediente = IdEx;
            ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(IdEx);
            return View();
        }

        public ActionResult InsertarExpediente(string Accion)
        {
            ViewBag.Accion = Accion;
            return View();
        }
        public ActionResult InsertarContacto(string Accion)
        {
            ViewBag.Accion = Accion;
            Contacto con = new Contacto();
            return View(con);
        }
        public ActionResult InsertarEvento(string Accion, int IdEx, int IdCont)
        {
            ViewBag.IdCont = IdCont;
            ViewBag.Idex = IdEx;
            ViewBag.Accion = Accion;
            Evento eve = new Evento();
            eve.IdExpediente = IdEx;
            eve.IdContacto = IdCont;
            return View(eve);
        }


        public ActionResult InsertarExpedienteFojas(string Accion, int IdEx)
        {
            ViewBag.Accion = Accion;
            ExpedienteFojas Expf = new ExpedienteFojas();
            Expf.IdExpediente = IdEx;
            return View(Expf);
        }

        public ActionResult FormExpediente(string Accion, int IdEx)
        {
            Expediente UnExpediente = BD.TraerExpediente(IdEx);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
               return View("EdicionExpediente", UnExpediente);
            }
            if (Accion=="Eliminar")
            {
                BD.Eliminar(IdEx);
                ViewBag.Expedientes = BD.TraerExpedientes();
                return View("ABMExpedientes");
            }
            if (Accion == "Agregar")
            {
                ViewBag.IdExpediente = IdEx;
                return View("AgregarArchivoExpediente");
            }

            return View("SinAccion");
        }


        [HttpPost]
        public ActionResult AgregarArchivo(HttpPostedFileBase archivo, int IdEx, string Nombre)
        {
            ViewBag.IdExpediente = IdEx;
            Archivos archi = new Archivos() ;
            archi.Nombre = Nombre;
            ExpedienteArchivo Exparchi = new ExpedienteArchivo();
            // Grabar en Base de datos el Archivo!
            Exparchi.IdArchivo = BD.InsertarArchivo(archi);
            Exparchi.Expediente = IdEx;
            BD.InsertarExpeArchivo(Exparchi);
            if (archivo.ContentLength > 0)
            {
                string extension = Path.GetExtension(archivo.FileName);
                var path = Server.MapPath("~/Content/Archivos/") + Nombre + archi.IdArchivo + "." + extension;
                archivo.SaveAs(path);
            }

            return RedirectToAction("ABMExpedientes");
        }


        public ActionResult FormContacto(string Accion, int IdCont)
        {
            Contacto UnContacto = BD.TraerContacto(IdCont);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionContacto", UnContacto);
            }
            if (Accion == "Eliminar")
            {
                BD.EliminarContactos(IdCont);
                ViewBag.Contactos = BD.TraerContactos();
                return View("ABMContactos");
            }
            return View("SinAccion");
        }

        public ActionResult FormExpedienteFojas(string Accion, int IdExpf,int IdEx)
        {
            ExpedienteFojas UnexpedienteFojas= BD.TraerExpediente_fojas(IdExpf);
            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionExpedienteFojas", UnexpedienteFojas);
            }
            if (Accion == "Eliminar")
            {
                BD.EliminarFojas(IdExpf);
                ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(IdEx);
                return View("ABMExpedienteFojas");
            }
            return View("SinAccion");
        }

        public ActionResult FormEvento(string Accion, int IdEx,int idEve, int IdCont = 0)
        {
            Evento UnEvento= BD.TraerEvento(idEve);

            ViewBag.Accion = Accion;
            if (Accion == "Obtener")
            {
                return View("EdicionEvento", UnEvento);
            }
            if (Accion == "Eliminar")
            {
                BD.EliminarEvento(idEve);
                ViewBag.IdContactos = IdCont;
                ViewBag.IdExpediente = IdEx;
                ViewBag.Eventos = BD.TraerEventos();
                return View("ABMEventos");
            }
            if (Accion == "Agregar")
            {
                Evento ev = new Evento();
                ViewBag.IdEvento= idEve;
                return View("AgregarEveArchivos",ev);
            }

            return View("SinAccion");
        }

        [HttpPost]
        public ActionResult AgregarArchivoEve(HttpPostedFileBase archivo, int idEve, string Nombre)
        {
            ViewBag.IdEvento = idEve;
            Archivos archi = new Archivos();
            archi.Nombre = Nombre;
            EventoArchi Evearchi = new EventoArchi();
            // Grabar en Base de datos el Archivo!
            Evearchi.IdArchivo = BD.InsertarArchivo(archi);
            Evearchi.IdEvento = idEve;
            BD.InsertarEvenArchivo(Evearchi);
            if (archivo.ContentLength > 0)
            {

                string extension = Path.GetExtension(archivo.FileName);
                var path = Server.MapPath("~/Content/Archivos/") + Nombre + archi.IdArchivo + "."+extension;
                archivo.SaveAs(path);
            }

            return RedirectToAction("ABMEventos");
        }


        [HttpPost]
        public ActionResult EdicionExpediente(Expediente ex, string Accion)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Expedientes = BD.TraerExpedientes();
                
                return View("ABMExpedientes");
            }
            else
            {
                if(Accion == "Obtener")
                {
                    BD.ModificarExpediente(ex);
                    ViewBag.Expedientes = BD.TraerExpedientes();
                    return View("ABMExpedientes");
                    }
                else
                {
                    if (Accion == "Insertar")
                    {
                        if (!ModelState.IsValid)
                        {
                            ViewBag.Expedientes = BD.InsertarExpediente(ex);
                            return View("InsertarExpediente");
                        }
                        else
                        {
                            BD.InsertarExpediente(ex);
                            ViewBag.Expedientes = BD.InsertarExpediente(ex);
                            return View("ABMExpedientes");
                        }
                    }
                }
            }
            ViewBag.Expedientes = BD.TraerExpedientes();
            return View("ABMExpedientes");
        }
        [HttpPost]
        public ActionResult EdicionContacto(Contacto cont, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarContacto(cont);
                    ViewBag.Contactos = BD.TraerContactos();
                    return View("ABMContactos");

                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarContacto(cont);
                        ViewBag.Contactos = BD.TraerContactos();
                        return View("ABMContactos");
                    }
                }
            }
            else
            {
                return View("InsertarContacto");
            }
            return View("Error");
        }


        [HttpPost]
        public ActionResult EdicionExpedienteFojas(ExpedienteFojas Expf, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "Obtener")
                {
                    BD.ModificarExpFojas(Expf);
                    ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(Expf.IdExpediente);
                    return View("ABMExpedienteFojas");

                }
                else
                {
                    if (Accion == "Insertar")
                    {
                        BD.InsertarFojas(Expf);
                        ViewBag.ExpedienteFojas = BD.TraerLasExpFojas(Expf.IdExpediente);
                        return View("ABMExpedienteFojas");
                    }
                }
            }
            else
            {
                return View("InsertarFojas");
            }
            return View("Error");
        }
        [HttpPost]
        public ActionResult EdicionEvento(Evento Eve, string Accion)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "Obtener")
                {
                    if (Eve.IdExpediente == 0 && Eve.IdContacto!= 0)
                    {
                        BD.ModificarEventoCont(Eve);
                        ViewBag.Contactos = BD.TraerContactos();
                        return View("ABMContactos");
                    }
                    else {
                        BD.ModificarEventoExp(Eve);
                        ViewBag.Expedientes = BD.TraerExpedientes();
                        return View("ABMExpedientes");
                    }

                }
                
            }
            else
            {
                ViewBag.Accion = Accion;
                return View("EdicionEvento", Eve);
            }
            return View("Error");
        }

        [HttpPost]
        public ActionResult InsercionEvento(Evento Eve, string Accion, int IdEx, int IdCont)
        {
            if (ModelState.IsValid)
            {
                if (Accion == "Insertar")
                {
                    if (IdEx == 0 && IdCont != 0)
                    {
                        Eve.IdContacto = IdCont;
                        BD.InsertarEventoCONT(Eve);
                        ViewBag.Evento = BD.TraerEvento(Eve.IdEvento);
                        return RedirectToAction("ABMEventos", new { Eve = Eve, IdEx = IdEx, IdCont = IdCont });
                    }
                    else
                    {
                        Eve.IdExpediente = IdEx;
                        BD.InsertarEventoExp(Eve);
                        ViewBag.Evento = BD.TraerEvento(Eve.IdEvento);
                        return RedirectToAction("ABMEventos", new { Eve = Eve, IdEx = IdEx, IdCont = IdCont });
                    }

                }
                
            }
            else
            {
                ViewBag.IdCont = IdCont;
                ViewBag.Idex = IdEx;
                ViewBag.Accion = Accion; Evento eve = new Evento();
                eve.IdExpediente = IdEx;
                eve.IdContacto = IdCont;
                return View("InsertarEvento", eve);
            }
            return View("Error");
        }
    }
}



  