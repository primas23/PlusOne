using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlusOne.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.Users = new HashSet<ApplicationUser>();
        }

        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public virtual Location Location { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
