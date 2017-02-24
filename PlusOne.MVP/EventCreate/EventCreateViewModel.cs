using System;
using System.Linq;

namespace PlusOne.MVP.EventCreate
{
    public class EventCreateViewModel
    {
        public virtual DateTime Start { get; set; }

        public virtual Guid EventTypeId { get; set; }

        public virtual DateTime End { get; set; }

        public virtual string LocationName { get; set; }

        public virtual double Latitude { get; set; }

        public virtual double Longitude { get; set; }

        public virtual string LocationAddress { get; set; }

        public virtual IQueryable<Data.Models.EventType> EventTypes { get; set; }
    }
}
