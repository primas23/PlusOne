using System;

using PlusOne.Data.Models;

namespace PlusOne.MVP.EditEvents
{
    public class EventEditEventArgs : EventArgs
    {
        public Event Event { get; set; }
    }
}
