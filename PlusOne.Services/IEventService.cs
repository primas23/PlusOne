using System;
using System.Collections.Generic;
using System.Linq;
using PlusOne.Data.Models;

namespace PlusOne.Services
{
    public interface IEventService
    {
        IQueryable<Event> GetAllEventsSortedByStartDate();

        IQueryable<Event> GetAllMyEventsSortedByStartDate(Guid userId);

        IQueryable<Event> GetAllEventsBySearchParams(string queryType, string queryLocation, DateTime queryStart, DateTime queryEnd);

        Event GetById(Guid? id);

        int InsertEvent(Event eventToInsert);

        int AddParticipant(Guid eventId, string userId);

        int RemoveParticipant(Guid eventId, string userId);
    }
}
