using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Industry
    {
        public Industry()
        {
            CompanyIndustries = new HashSet<CompanyIndustry>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<CompanyIndustry> CompanyIndustries { get; set; }
    }
}
