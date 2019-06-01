using Organizator.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organizator.BLL
{
    
    public class PersonBLL
    {
        DataContext db = new DataContext();

        public void Register(Person person)
        {
            db.Person.Add(person);
            db.SaveChanges();
        }
        public Person Login(Person person)
        {
            return db.Person.FirstOrDefault(x => x.UserName == person.UserName && x.Password == person.Password);
        }
        public Person PersonDetail(int id)
        {
            return db.Person.FirstOrDefault(x => x.PersonID == id);
        }
        public void UpdatePerson(Person person)
        {
            db.SaveChanges();
        }
    }
}
