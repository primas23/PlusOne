using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using PlusOne.Data.Models;

namespace PlusOne.Data
{
    public class PlusOneDbContext : IdentityDbContext<ApplicationUser>, IPlusOneDbContext
    {
        public PlusOneDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public IDbSet<Event> Events{ get; set; }

        public IDbSet<EventType> EventTypes { get; set; }

        public IDbSet<Location> Locations { get; set; }

        public static PlusOneDbContext Create()
        {
            return new PlusOneDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().
                HasMany(c => c.Participants);
            modelBuilder.Entity<ApplicationUser>().
                HasMany(c => c.Events);

            base.OnModelCreating(modelBuilder);
        }
    }
}
