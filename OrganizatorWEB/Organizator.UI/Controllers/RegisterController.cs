using Organizator.BLL;
using Organizator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizator.UI.Controllers
{
    public class RegisterController : Controller
    {
        PersonBLL personBLL = new PersonBLL();
        // GET: Register
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Person person)
        {
            personBLL.Register(person);
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Person person)
        {
            var p = personBLL.Login(person);
            if (p!=null)
            {
                Session["Login"] = p;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return RedirectToAction("LoginHata");
            }
        }
        public ActionResult LoginHata()
        {
            return View();
        }
    }
}