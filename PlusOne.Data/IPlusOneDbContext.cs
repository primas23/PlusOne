using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusOne.Data.Models;

namespace PlusOne.Data
{
    public interface IPlusOneDbContext
    {
        IDbSet<City> Cities { get; set; }

        IDbSet<Event> Events { get; set; }

        IDbSet<EventType> EventTypes { get; set; }

        IDbSet<Location> Locations { get; set; }
    }
}
