using System;
using System.Collections.Generic;
using System.Linq;
using PlusOne.Data.Models;

namespace PlusOne.Services
{
    public interface IEventService
    {
        IList<Event> GetAllEventsSortedByStartDate();

        IQueryable<Event> GetAllEventsBySearchParams(string queryType, string queryLocation, DateTime queryStart, DateTime queryEnd);

        Event GetById(Guid? id);
    }
}
