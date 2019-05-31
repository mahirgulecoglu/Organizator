using Organizator.BLL;
using Organizator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Organizator.UI.Controllers
{
    public class EventController : Controller
    {
        EventBLL eventBLL = new EventBLL();
        // GET: Event
        public ActionResult AddEvent()
        {
            return View(new Event());
        }
        [HttpPost]
        public ActionResult AddEvent(Event events)
        {
            var person = (Person)Session["Login"];
            events.PersonID = person.PersonID;
            events.CreatedDate = DateTime.Now;
            eventBLL.AddEvent(events);
            return RedirectToAction("GetEvents", "Event");
        }
        public ActionResult GetEvents()
        {
            var model = eventBLL.GetEvents();
            return View(model);
        }
        public ActionResult EventDetail(int id)
        {
            var model = eventBLL.EventDetail(id);
            return View(model);
        }
        
        public ActionResult UserGetEvents()
        {
            var person = (Person)Session["Login"];
            var model = eventBLL.UserGetEvents(person.PersonID);
            return View(model);
        }

        public ActionResult DeleteEvent(int id)
        {
            eventBLL.DeleteEvent(id);
            return RedirectToAction("UserGetEvents", "Event");
        }
        public ActionResult JoinEvent()
        {
            return View(new EventPeople());
        }
        [HttpPost]
        public ActionResult JoinEvent(EventPeople events)
        {
            var person = (Person)Session["Login"];
            events.PersonID = person.PersonID;
            return RedirectToAction("GetEvents", "Event");
        }
    }
}