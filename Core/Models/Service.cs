using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Service : BaseEntity
    {
        public Service()
        {
            PartnerServices = new HashSet<PartnerService>();
        }

       
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }

        public virtual ICollection<PartnerService> PartnerServices { get; set; }
    }
}
