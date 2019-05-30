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
    }
}
