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
    }
}
