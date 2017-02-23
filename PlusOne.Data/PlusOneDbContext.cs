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

        public IDbSet<City> Cities { get; set; }

        public IDbSet<Event> Events{ get; set; }

        public IDbSet<EventType> EventTypes { get; set; }

        public IDbSet<Location> Locations { get; set; }
        
        public static PlusOneDbContext Create()
        {
            return new PlusOneDbContext();
        }
    }
}
