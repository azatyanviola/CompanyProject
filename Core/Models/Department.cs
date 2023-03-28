using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Department : BaseEntity
    {
        public Department()
        {
            CompanyDepartments = new HashSet<CompanyDepartment>();
            Positions = new HashSet<Position>();
        }

       
        public string Name { get; set; } = null!;

        public virtual ICollection<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual ICollection<Position> Positions { get; set; }
    }
}
