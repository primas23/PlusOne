using System.Linq;

using PlusOne.Data.Models;

namespace PlusOne.Services
{
    public interface IEventTypeService
    {
        IQueryable<EventType> GetAllEventTypes();

        int InsertEvent(EventType eventTypeToInsert);
    }
}
