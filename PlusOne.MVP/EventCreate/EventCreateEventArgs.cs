using System;

namespace PlusOne.MVP.EventCreate
{
    public class EventCreateEventArgs : EventArgs
    {
        public Guid EventId { get; set; }

        public DateTime Start { get; private set; }

        public DateTime End { get; private set; }

        public string EventType { get; private set; }

        public string LocationName { get; private set; }

        public double Latitude { get; private set; }

        public double Longitude { get; private set; }

        public string LocationAddress { get; private set; }
    }
}
