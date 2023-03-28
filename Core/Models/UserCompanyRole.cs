using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class UserCompanyRole : BaseEntity
    {
     
        public int? UserCompanyId { get; set; }
        public int? RoleId { get; set; }

        public virtual UserRole? Role { get; set; }
        public virtual UserCompany? UserCompany { get; set; }
    }
}
