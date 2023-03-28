using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Region : BaseEntity
    {
        public Region()
        {
            Cities = new HashSet<City>();
        }

       
        public string? Name { get; set; }
        public int? CountryId { get; set; }

        public virtual Country? Country { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
