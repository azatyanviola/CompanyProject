using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class UserRole : BaseEntity
    {
        public UserRole()
        {
            UserCompanyRoles = new HashSet<UserCompanyRole>();
        }

        
        public string Name { get; set; } = null!;

        public virtual ICollection<UserCompanyRole> UserCompanyRoles { get; set; }
    }
}
