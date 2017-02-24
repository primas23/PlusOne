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
            return this._context.Events
                .Where(e => e.IsDeleted == false)
                .OrderBy(e => e.Start)
                .Include(e => e.Type);
        }

        public IQueryable<Event> GetAllEventsInDataBase()
        {
            return this._context.Events
                .OrderBy(e => e.Start)
                .Include(e => e.Type);
        }

        public IQueryable<Event> GetAllMyEventsSortedByStartDate(Guid userId)
        {
            return this._context.Events
                .Where(e => e.IsDeleted == false)
                .Where(e => e.Participants.Any(p => p.Id == userId.ToString()))
                .OrderBy(e => e.Start);
        }

        public IQueryable<Event> GetAllEventsBySearchParams(string queryType, string queryLocation, DateTime queryStart, DateTime queryEnd)
        {
            IQueryable<Event> events = this._context.Events
                .OrderBy(e => e.Start);

            if (string.IsNullOrEmpty(queryType) == false)
            {
                events = events.Where(e => e.Type.Name.Contains(queryType));
            }

            if (string.IsNullOrEmpty(queryLocation) == false)
            {
                events = events.Where(e => e.Location.Address.Contains(queryLocation));
            }

            if (queryStart > DateTime.MinValue.AddMinutes(1))
            {
                events = events.Where(e => e.Start >= queryStart);
            }

            if (queryEnd < DateTime.MaxValue.AddMinutes(-1))
            {
                events = events.Where(e => e.End <= queryEnd);
            }

            return events;
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

        public int DeleteEvent(Guid id)
        {
            Event eventTodelete = this._context.Events.FirstOrDefault(e => e.Id == id);

            eventTodelete.IsDeleted = true;

            return this._context.SaveChanges();
        }

        public int UpdateEvent(Event evnetToUpdatEvent)
        {
            var entry = this._context.Entry(evnetToUpdatEvent);
            entry.State = EntityState.Modified;

            return this._context.SaveChanges();
        }
    }


}
