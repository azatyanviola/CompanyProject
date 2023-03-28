using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class City :BaseEntity
    {
        public City()
        {
            Addresses = new HashSet<Address>();
        }

       
        public string? Name { get; set; }
        public int? RegionId { get; set; }

        public virtual Region? Region { get; set; }
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
