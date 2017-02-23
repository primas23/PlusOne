using System;
using System.Collections.Generic;
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

        public IList<Event> GetAllEventsSortedByStartDate()
        {
            return this._context.Events.OrderBy(e => e.Start).ToList();
        }

        public Event GetById(Guid? id)
        {
            return this._context.Events.Find(id);
        }
    }
}
