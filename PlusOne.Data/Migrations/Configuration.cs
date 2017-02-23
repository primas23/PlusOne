using System;
using System.Data.Entity.Migrations;
using System.Linq;
using PlusOne.Data.Models;

namespace PlusOne.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<PlusOneDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(PlusOneDbContext context)
        {
            if (context.EventTypes.Any())
            {
                return;
            }

            var futbolType = new EventType()
            {
                Id = Guid.NewGuid(),
                Name = "Football"
            };

            var golfType = new EventType()
            {
                Id = Guid.NewGuid(),
                Name = "Golf"
            };

            context.EventTypes.Add(futbolType);
            context.EventTypes.Add(golfType);

            var footbalLoc = new Location()
            {
                Id = Guid.NewGuid(),
                City = new City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Sofia"
                },
                Name = "U nas",
                Address = "nor 4",
                MapUrl = "kjausdholidahfkljjalkjsd"
            };

            var golflLoc = new Location()
            {
                Id = Guid.NewGuid(),
                City = new City()
                {
                    Id = Guid.NewGuid(),
                    Name = "Pleven"
                },
                Name = "U tqh",
                Address = "asdasd 4",
                MapUrl = "asdasd"
            };

            context.Locations.Add(golflLoc);
            context.Locations.Add(footbalLoc);
            

            var footvalEvent = new Event()
            {
                Id = Guid.NewGuid(),
                Location = footbalLoc,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                Type = futbolType
            };

            var golfEvent = new Event()
            {
                Id = Guid.NewGuid(),
                Location = golflLoc,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(2),
                Type = golfType
            };

            context.Events.Add(footvalEvent);
            context.Events.Add(golfEvent);


            context.SaveChanges();
        }
    }
}
