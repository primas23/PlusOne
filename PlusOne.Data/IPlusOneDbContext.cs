using System.Data.Entity;
using System.Data.Entity.Infrastructure;

using PlusOne.Data.Models;

namespace PlusOne.Data
{
    public interface IPlusOneDbContext
    {
        IDbSet<Event> Events { get; set; }

        IDbSet<EventType> EventTypes { get; set; }

        IDbSet<Location> Locations { get; set; }

        IDbSet<ApplicationUser> Users { get; set; }

        DbEntityEntry Entry(object entity);

        int SaveChanges();
    }
}
