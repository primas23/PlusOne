using System;
using System.Collections.Generic;

namespace PlusOne.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
            this.Users = new HashSet<ApplicationUser>();
            this.CreatedOn = DateTime.Now;
        }

        public Guid Id { get; private set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime CreatedOn { get; private set; }

        public string Comments { get; set; }

        public Guid TypeId { get; set; }

        public virtual EventType Type { get; set; }

        public virtual Location Location { get; set; }

        public Guid ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<ApplicationUser> Users { get; set; }
    }
}
