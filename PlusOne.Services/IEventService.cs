using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlusOne.Data.Models;

namespace PlusOne.Services
{
    public interface IEventService
    {
        IList<Event> GetAllEventsSortedByStartDate();

        Event GetById(Guid? id);
    }
}
