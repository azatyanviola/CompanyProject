using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Position : BaseEntity
    {
        public Position()
        {
            UserCompanies = new HashSet<UserCompany>();
        }

       
        public string? Name { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Department? Department { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
