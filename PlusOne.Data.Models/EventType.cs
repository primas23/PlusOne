using System;
using System.Collections.Generic;

namespace PlusOne.Data.Models
{
    public class EventType
    {
        public EventType()
        {
            this.Events = new HashSet<Event>();
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> Events { get; set; }

    }
}
