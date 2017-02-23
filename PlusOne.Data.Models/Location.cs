﻿using System;

namespace PlusOne.Data.Models
{
    public class Location
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public virtual City City { get; set; }

        public string Address { get; set; }

        public string MapUrl { get; set; }
    }
}
