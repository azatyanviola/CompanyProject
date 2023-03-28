using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PhoneCode : BaseEntity
    {
        public PhoneCode()
        {
            Companies = new HashSet<Company>();
            Users = new HashSet<User>();
        }

       
        public string? Code { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
