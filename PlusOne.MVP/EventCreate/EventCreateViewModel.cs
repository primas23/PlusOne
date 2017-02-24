using System;
using System.Linq;

namespace PlusOne.MVP.EventCreate
{
    public class EventCreateViewModel
    {
        public DateTime Start { get; set; }

        public Guid EventTypeId { get; set; }

        public DateTime End { get; set; }

        public string LocationName { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string LocationAddress { get; set; }

        public IQueryable<Data.Models.EventType> EventTypes { get; set; }
    }
}
