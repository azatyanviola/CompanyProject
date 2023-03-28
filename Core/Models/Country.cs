using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Country : BaseEntity
    {
        public Country()
        {
            Regions = new HashSet<Region>();
        }

        
        public string? Name { get; set; }

        public virtual ICollection<Region> Regions { get; set; }
    }
}
