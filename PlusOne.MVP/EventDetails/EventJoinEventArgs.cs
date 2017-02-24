using System;

namespace PlusOne.MVP.EventDetails
{
    public class EventJoinEventArgs : EventArgs
    {
        public string UserId { get; set; }

        public Guid EventId { get; set; }
    }
}
