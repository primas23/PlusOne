using System;

namespace PlusOne.Data.Models
{
    public class Location
    {
        public Location()
        {
            this.Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; }

        public string Name { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public string Address { get; set; }
    }
}
