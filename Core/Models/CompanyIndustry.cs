using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class CompanyIndustry : BaseEntity
    {
        
        public int? CompanyId { get; set; }
        public int? IndustryId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Industry? Industry { get; set; }
    }
}
