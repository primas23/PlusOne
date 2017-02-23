using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusOne.Data.Models;

namespace PlusOne.MVP.Events
{
    public class EventsViewModel
    {
        public IList<Event> Events { get; set; }
    }
}
