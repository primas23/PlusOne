using System.Data.Entity;
using PlusOne.Data.Models;

namespace PlusOne.Data
{
    public interface IPlusOneDbContext
    {
        IDbSet<Event> Events { get; set; }

        IDbSet<EventType> EventTypes { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        int SaveChanges();
    }
}
