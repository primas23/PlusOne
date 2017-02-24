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
            return this._context.Events.OrderBy(e => e.Start).Include(e => e.Type);
        }

        public IQueryable<Event> GetAllMyEventsSortedByStartDate(Guid userId)
        {
            return this._context.Events.Where(e => e.Participants.Any(p => p.Id == userId.ToString())).OrderBy(e => e.Start);
        }

        public IQueryable<Event> GetAllEventsBySearchParams(string queryType, string queryLocation, DateTime queryStart, DateTime queryEnd)
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

        public int AddParticipant(Guid eventId, string userId)
        {
            ApplicationUser user = this._context.Users.Find(userId);
            Event eventToPopulatEvent = this._context.Events.Find(eventId);

            if (eventToPopulatEvent.MaxParticipants > eventToPopulatEvent.Participants.Count())
            {
                eventToPopulatEvent.Participants.Add(user);
            }

            return _context.SaveChanges();
        }

        public int RemoveParticipant(Guid eventId, string userId)
        {
            ApplicationUser user = this._context.Users.Find(userId);
            Event eventToPopulatEvent = this._context.Events.Find(eventId);

            if (eventToPopulatEvent.Participants.Any())
            {
                eventToPopulatEvent.Participants.Remove(user);
            }

            return _context.SaveChanges();
        }
    }
}
