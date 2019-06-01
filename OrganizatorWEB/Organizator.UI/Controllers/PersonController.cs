using Organizator.BLL;
using Organizator.Entity;
using Organizator.UI.Filter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizator.UI.Controllers
{
    public class PersonController : Controller
    {
        PersonBLL personBLL = new PersonBLL();
        // GET: Person
        [LoginFilter]
        public ActionResult PersonDetail()
        {
            var person = (Person)Session["Login"];
            var model = personBLL.PersonDetail(person.PersonID);
            return View(model);
        }
    }
}