using System;
using System.Collections.Generic;

namespace PlusOne.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.Id = Guid.NewGuid();
            this.Participants = new HashSet<ApplicationUser>();
            this.CreatedOn = DateTime.Now;
        }

        public Guid Id { get; set; }

        public DateTime Start { get; set; }

        public DateTime End { get; set; }

        public DateTime CreatedOn { get; private set; }

        public bool IsDeleted { get; set; }

        public string Comments { get; set; }

        public int MaxParticipants { get; set; }

        public Guid TypeId { get; set; }

        public virtual EventType Type { get; set; }

        public Guid LocationId { get; set; }

        public virtual Location Location { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; }
    }
}
