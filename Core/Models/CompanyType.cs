using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class CompanyType : BaseEntity
    {
       
        public int? CompanyId { get; set; }
        public int? TypeId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Type? Type { get; set; }
    }
}
