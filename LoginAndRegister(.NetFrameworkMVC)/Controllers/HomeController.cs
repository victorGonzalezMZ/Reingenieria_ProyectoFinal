using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAndRegister_.NetFrameworkMVC_.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Id"] != null)
                return View();
            else
                return RedirectToAction("LoginIndex", "Login");

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Logout()
        {
            Session["Id"] = null;
            return RedirectToAction("LoginIndex", "Login");
        }

        public ActionResult ToEmpleado()
        {
            return RedirectToAction("Index", "Empleado");
        }

        public ActionResult ToProducto()
        {
            return RedirectToAction("Index", "Producto");
        }
    }
}