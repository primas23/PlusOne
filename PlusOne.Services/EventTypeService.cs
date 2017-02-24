using System.Linq;
using PlusOne.Data;
using PlusOne.Data.Models;

namespace PlusOne.Services
{
    public class EventTypeService : IEventTypeService
    {
        private readonly IPlusOneDbContext _context;

        public EventTypeService(IPlusOneDbContext context)
        {
            this._context = context;
        }

        public IQueryable<EventType> GetAllEventTypes()
        {
            return this._context.EventTypes;
        }

        public int InsertEvent(EventType eventTypeToInsert)
        {
            this._context.EventTypes.Add(eventTypeToInsert);

            return this._context.SaveChanges();
        }
    }
}
