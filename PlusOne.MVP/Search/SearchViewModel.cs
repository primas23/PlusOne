using System.Linq;
using PlusOne.Data.Models;

namespace PlusOne.MVP.Search
{
    public class SearchViewModel
    {
        public IQueryable<Event> Events { get; set; }
    }
}
