using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlusOne.Data;
using PlusOne.Data.Models;

namespace PlusOne.Services
{
    public class EventService : IEventService
    {
        private readonly IPlusOneDbContext _context;

        public EventService(IPlusOneDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Event> GetAllEventsSortedByStartDate()
        {
            return this._context.Events.OrderBy(e => e.Start).Include(e => e.Type); ;
        }

        public IQueryable<Event> GetAllEventsBySearchParams(string queryType, string queryLocation , DateTime queryStart, DateTime queryEnd)
        {
            // TODO: Add logic
            return this._context.Events.OrderBy(e => e.Start);
        }

        public Event GetById(Guid? id)
        {
            return this._context.Events.Find(id);
        }

        public int InsertEvent(Event eventToInsert)
        {
            this._context.Events.Add(eventToInsert);

            return this._context.SaveChanges();
        }
    }
}
