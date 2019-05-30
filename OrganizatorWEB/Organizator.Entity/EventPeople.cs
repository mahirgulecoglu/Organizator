namespace Organizator.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("EventPeople")]
    public partial class EventPeople
    {
        public int ID { get; set; }

        public int PersonID { get; set; }

        public int EventID { get; set; }

        public int TotalPerson { get; set; }

        public virtual Event Event { get; set; }

        public virtual Person Person { get; set; }
    }
}
