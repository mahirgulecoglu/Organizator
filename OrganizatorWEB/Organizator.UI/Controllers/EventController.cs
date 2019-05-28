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
            return View();
        }
        [HttpPost]
        public ActionResult AddEvent(Event events)
        {
            eventBLL.AddEvent(events);
            return RedirectToAction("Detail", "Event");
        }
    }
}