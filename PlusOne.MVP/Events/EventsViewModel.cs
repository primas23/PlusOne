using System.Collections.Generic;
using System.Linq;
using PlusOne.Data.Models;

namespace PlusOne.MVP.Events
{
    public class EventsViewModel
    {
        public IQueryable<Event> Events { get; set; }
    }
}
