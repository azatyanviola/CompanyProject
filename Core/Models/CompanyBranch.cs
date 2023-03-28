using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class CompanyBranch : BaseEntity
    {
      
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }

        public virtual Company? Branch { get; set; }
        public virtual Company? Company { get; set; }
    }
}
