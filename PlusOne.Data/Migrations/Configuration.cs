using System;
using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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

            this.SeedUsers(context);
            this.SeedRoles(context);
            this.SeedData(context);
        }

        private void SeedData(PlusOneDbContext context)
        {
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

            var chessType = new EventType()
            {
                Id = Guid.NewGuid(),
                Name = "Chess"
            };

            context.EventTypes.Add(futbolType);
            context.EventTypes.Add(chessType);
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
                Address = "ulitsa \"Akademik Boris Stefanov\" 14, 1700 Sofia, Bulgaria",
                Name = "asdasd 4",
                Latitude = 42.6483173,
                Longitude = 23.341426700000056,
            };

            var chesslLoc = new Location()
            {
                Address = "ulitsa \"Akademik Asd Stefanov\" 14, 1700 Pleven, Bulgaria",
                Name = "asdasd 4",
                Latitude = 52.6483173,
                Longitude = 33.341426700000056,
            };

            context.Locations.Add(golflLoc);
            context.Locations.Add(chesslLoc);
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

            var chessEvent = new Event()
            {
                Location = chesslLoc,
                Start = DateTime.Now,
                End = DateTime.Now.AddDays(2),
                Type = chessType,
                MaxParticipants = 2
            };

            context.Events.Add(footvalEvent);
            context.Events.Add(golfEvent);

            context.SaveChanges();
        }

        private void SeedUsers(PlusOneDbContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var admin = new ApplicationUser()
            {
                UserName = "admin@admin.bg",
                Email = "admin@admin.bg",
                PasswordHash = new PasswordHasher().HashPassword("admin"),
                LockoutEnabled = true,
                SecurityStamp = Guid.NewGuid().ToString()
            };
           

            context.Users.Add(admin);

            context.SaveChanges();
        }

        private void SeedRoles(PlusOneDbContext context)
        {
            if (context.Roles.Any())
            {
                return;
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            roleManager.Create(new IdentityRole("Admin"));
            
            context.SaveChanges();

            var admin = context.Users.FirstOrDefault(u => u.Email == "admin@admin.bg");
            if (admin != null)
            {
                userManager.AddToRole(admin.Id, "Admin");
            }
            
            context.SaveChanges();
        }
    }
}
