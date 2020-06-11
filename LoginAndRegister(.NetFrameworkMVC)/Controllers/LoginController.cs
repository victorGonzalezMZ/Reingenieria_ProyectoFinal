using LoginAndRegister_.NetFrameworkMVC_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LoginAndRegister_.NetFrameworkMVC_.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult LoginIndex()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(Models.User userModel)
        {
            using (DB_LoginEntities dbLogin = new DB_LoginEntities())
            {
                var userDetails = dbLogin.Users.Where(x => x.Username == userModel.Username
                && x.Password == userModel.Password).FirstOrDefault();

                if(userDetails == null)
                {
                    userModel.LoginErrorMessage = "Usuario y/o Contraseña invalidos.";
                    return View("LoginIndex", userModel);
                }
                else
                {
                    Session["Id"] = userDetails.Id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}