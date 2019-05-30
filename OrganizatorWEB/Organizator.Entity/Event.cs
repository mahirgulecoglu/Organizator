namespace Organizator.Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Event")]
    public partial class Event
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Event()
        {
            EventPeople = new HashSet<EventPeople>();
        }

        public int EventID { get; set; }

        [Required]
        [StringLength(50)]
        public string EventName { get; set; }

        [Column(TypeName = "date")]
        public DateTime CreatedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ApplicationDate { get; set; }

        public int Subscribers { get; set; }

        [Required]
        [StringLength(255)]
        public string EventImage { get; set; }

        public int CategoryID { get; set; }

        public int PersonID { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(250)]
        public string Description { get; set; }

        public virtual Categories Categories { get; set; }

        public virtual Person Person { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventPeople> EventPeople { get; set; }
    }
}
