namespace Organizator.Entity
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DataContext : DbContext
    {
        public DataContext()
            : base("name=DataContext")
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<Message> Message { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Categories)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Event)
                .WithRequired(e => e.Person)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Message)
                .WithRequired(e => e.Person)
                .HasForeignKey(e => e.MessageBy)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Person>()
                .HasMany(e => e.Message1)
                .WithRequired(e => e.Person1)
                .HasForeignKey(e => e.MessageTo)
                .WillCascadeOnDelete(false);
        }
    }
}
