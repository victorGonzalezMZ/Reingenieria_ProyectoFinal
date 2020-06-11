using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LoginAndRegister_.NetFrameworkMVC_.Models;

namespace LoginAndRegister_.NetFrameworkMVC_.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
        public ActionResult Index()
        {
            if (Session["Id"] != null)
            {
                using (DB_EmpleadosEntities dbModel = new DB_EmpleadosEntities())
                    return View(dbModel.Empleados.ToList());
            }
            else
                return RedirectToAction("LoginIndex", "Login");
            
        }

        [HttpGet]
        public ActionResult AddOrEdit()
        {
            if (Session["Id"] != null)
            {
                Empleado emp = new Empleado();
                return View(emp);
            }
            else
                return RedirectToAction("LoginIndex", "Login");
            
        }

        [HttpPost]
        public ActionResult AddOrEdit(Empleado empleado)
        {
            using (DB_EmpleadosEntities dbModel = new DB_EmpleadosEntities())
            {
                if (dbModel.Empleados.Any(x => x.Username == empleado.Username))
                {
                    ViewBag.DuplicateMessage = "El usuario ya existe";
                    return View("AddOrEdit", empleado);
                }

                dbModel.Empleados.Add(empleado);
                dbModel.SaveChanges();
            }
            ModelState.Clear();
            ViewBag.SuccessMessage = "Registro Exitoso";
            return View("AddOrEdit", new Empleado());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            if (Session["Id"] != null)
            {
                using (DB_EmpleadosEntities dbModel = new DB_EmpleadosEntities())
                    return View(dbModel.Empleados.Where(x => x.Id == id).FirstOrDefault());
            }
            else
                return RedirectToAction("LoginIndex", "Login");
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DB_EmpleadosEntities dbModel = new DB_EmpleadosEntities())
                {
                    Empleado emp = dbModel.Empleados.Where(x => x.Id == id).FirstOrDefault();
                    dbModel.Empleados.Remove(emp);
                    dbModel.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session["Id"] = null;
            return RedirectToAction("LoginIndex", "Login");
        }

        public ActionResult ToHome()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}