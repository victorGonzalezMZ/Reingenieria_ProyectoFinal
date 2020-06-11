using LoginAndRegister_.NetFrameworkMVC_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAndRegister_.NetFrameworkMVC_.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                using (Productos_SoftwareEntities dbModel = new Productos_SoftwareEntities())
                    return View(dbModel.Proyectos.ToList());
            }
            else
                return RedirectToAction("LoginIndex", "Login");  
        }

        [HttpGet]
        public ActionResult AddOrEdit()
        {
            if (Session["Id"] != null)
            {
                Proyecto pro = new Proyecto();
                return View(pro);
            }
            else
                return RedirectToAction("LoginIndex", "Login");
        }

        [HttpPost]
        public ActionResult AddOrEdit(Proyecto proyecto)
        {
            using (Productos_SoftwareEntities dbModel = new Productos_SoftwareEntities())
            {
                if (dbModel.Proyectos.Any(x => x.NombreProyecto == proyecto.NombreProyecto))
                {
                    ViewBag.DuplicateMessage = "El proyecto ya existe";
                    return View("AddOrEdit", proyecto);
                }

                dbModel.Proyectos.Add(proyecto);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro Exitoso";
            return View("AddOrEdit", new Proyecto());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Id"] != null)
            {
                using (Productos_SoftwareEntities dbModel = new Productos_SoftwareEntities())
                    return View(dbModel.Proyectos.Where(x => x.IdProyecto == id).FirstOrDefault());
            }
            else
                return RedirectToAction("LoginIndex", "Login");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (Productos_SoftwareEntities dbModel = new Productos_SoftwareEntities())
                {
                    Proyecto pro = dbModel.Proyectos.Where(x => x.IdProyecto == id).FirstOrDefault();
                    dbModel.Proyectos.Remove(pro);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult ToHome()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["Id"] = null;
            return RedirectToAction("LoginIndex", "Login");
        }
    }
}