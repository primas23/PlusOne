using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using PlusOne.Data.Models;

namespace PlusOne.Data
{
    public class PlusOneDbContext : IdentityDbContext<ApplicationUser>
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
