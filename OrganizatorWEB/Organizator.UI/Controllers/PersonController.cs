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
        [LoginFilter]
        public ActionResult UpdatePerson(int id)
        {
            var p = personBLL.PersonDetail(id);
            return View(p);
        }
        [LoginFilter]
        [HttpPost]
        public ActionResult UpdatePerson(Person p)
        {
            Person person = personBLL.PersonDetail(p.PersonID);
            person.FirstName = p.FirstName;
            person.LastName = p.LastName;
            person.UserName = p.UserName;
            person.Password = p.Password;
            person.DateOfBirth = p.DateOfBirth;
            person.Email = p.Email;
            personBLL.UpdatePerson(person);
            return RedirectToAction("PersonDetail","Person");
        }
        [LoginFilter]
        public ActionResult GetPeoples(int id)
        {
            var model = personBLL.GetPeoples(id);
            return View(model);
        }
    }
}