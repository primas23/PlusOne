using System.Linq;

using PlusOne.Data.Models;

namespace PlusOne.MVP.Events
{
    public class EventsViewModel
    {
        public virtual IQueryable<Event> Events { get; set; }
    }
}
