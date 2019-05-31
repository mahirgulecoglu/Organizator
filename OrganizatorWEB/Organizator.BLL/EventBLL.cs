using Organizator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.BLL
{
    public class EventBLL
    {
        DataContext db = new DataContext();

        public void AddEvent(Event events)
        {
            db.Event.Add(events);
            db.SaveChanges();
        }
        public List<Event> GetEvents()
        {
            return db.Event.ToList();
        }

        public Event EventDetail(int id)
        {
            return db.Event.FirstOrDefault(x => x.EventID == id);
        }

        public List<Categories> GetCategories()
        {
            return db.Categories.ToList();
        }

        public List<Event> UserGetEvents(int id)
        {
            return db.Event.Where(x => x.PersonID == id).ToList();
        }

        public void DeleteEvent(int id)
        {
            Event events = new Event();
            events = db.Event.Where(x => x.EventID == id).FirstOrDefault();
            db.Event.Remove(events);
            db.SaveChanges();
        }

        public void JoinEvent(EventPeople events)
        {
            db.EventPeople.Add(events);
            db.SaveChanges();
        }
    }
}
