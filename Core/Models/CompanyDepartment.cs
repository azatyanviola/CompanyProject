using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class CompanyDepartment :BaseEntity
    {
        
        public int? CompanyId { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Company? Company { get; set; }
        public virtual Department? Department { get; set; }
    }
}
