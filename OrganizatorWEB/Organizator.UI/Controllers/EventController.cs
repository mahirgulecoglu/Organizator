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
    public class EventController : Controller
    {
        EventBLL eventBLL = new EventBLL();
        // GET: Event
        [LoginFilter]
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
        [LoginFilter]
        public ActionResult GetEvents()
        {
            var model = eventBLL.GetEvents();
            return View(model);
        }
        [LoginFilter]
        public ActionResult EventDetail(int id)
        {
            if (Session["ID"]!=null)
            {
                Session.Remove("ID");
            }
            var model = eventBLL.EventDetail(id);
            if (model != null)
            {
                Session["ID"] = model.EventID;
            }
            return View(model);
        }
        [LoginFilter]
        public ActionResult UserGetEvents()
        {
            var person = (Person)Session["Login"];
            var model = eventBLL.UserGetEvents(person.PersonID);
            return View(model);
        }
        [LoginFilter]
        public ActionResult DeleteEvent(int id)
        {
            eventBLL.DeleteEvent(id);
            return RedirectToAction("UserGetEvents", "Event");
        }
        [LoginFilter]
        public ActionResult JoinEvent()
        {
            return View(new EventPeople());
        }
        [HttpPost]
        public ActionResult JoinEvent(EventPeople events)
        {
            var person = (Person)Session["Login"];
            events.EventID = (int)Session["ID"];
            events.PersonID = person.PersonID;
            eventBLL.JoinEvent(events);
            return RedirectToAction("GetEvents", "Event");
        }
        [LoginFilter]
        public ActionResult GetJoinedEvent()
        {
            var person = (Person)Session["Login"];
            var model = eventBLL.GetJoinedEvent(person.PersonID);
            return View(model);
        }
        [LoginFilter]
        public ActionResult DeleteJoinedEvent(int id)
        {
            eventBLL.DeleteJoinedEvent(id);
            return RedirectToAction("GetJoinedEvent", "Event");
        }
        
    }
}