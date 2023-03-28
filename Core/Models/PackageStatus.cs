using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PackageStatus : BaseEntity
    {
        public PackageStatus()
        {
            Packages = new HashSet<Package>();
        }

        
        public string? Name { get; set; }

        public virtual ICollection<Package> Packages { get; set; }
    }
}
