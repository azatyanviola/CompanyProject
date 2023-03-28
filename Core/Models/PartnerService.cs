using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PartnerService : BaseEntity
    {
   
        public int? CompanyId { get; set; }
        public int? ServiceId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Service? Service { get; set; }
    }
}
