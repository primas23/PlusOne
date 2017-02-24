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
                Name = "U nas",
                Address = "ul. \"Anton Naydenov\" 12, 1700 Sofia, Bulgaria",
                Latitude = 42.65000430000001,
                Longitude = 23.341308099999992,
            };

            var golflLoc = new Location()
            {
                Name = "ulitsa \"Akademik Boris Stefanov\" 14, 1700 Sofia, Bulgaria",
                Address = "asdasd 4",
                Latitude = 42.6483173,
                Longitude = 23.341426700000056,
            };

            context.Locations.Add(golflLoc);
            context.Locations.Add(footbalLoc);


            var footvalEvent = new Event()
            {
                Location = footbalLoc,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(1),
                Type = futbolType,
                MaxParticipants = 5
            };

            var golfEvent = new Event()
            {
                Location = golflLoc,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(2),
                Type = golfType,
                MaxParticipants = 5
            };

            context.Events.Add(footvalEvent);
            context.Events.Add(golfEvent);


            context.SaveChanges();
        }
    }
}
