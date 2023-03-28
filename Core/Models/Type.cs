using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Type : BaseEntity
    {
        public Type()
        {
            CompanyTypes = new HashSet<CompanyType>();
        }

       
        public string? Type1 { get; set; }

        public virtual ICollection<CompanyType> CompanyTypes { get; set; }
    }
}
