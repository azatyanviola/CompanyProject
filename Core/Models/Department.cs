using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Department : BaseEntity
    {
        public Department()
        {
            CompanyDepartments = new HashSet<CompanyDepartment>();
            UserCompanies = new HashSet<UserCompany>();
        }

       
        public string Name { get; set; } = null!;

        public virtual ICollection<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
