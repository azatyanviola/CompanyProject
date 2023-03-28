using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class PackagePartner : BaseEntity
    {
       
        public int? PackageId { get; set; }
        public int? PartnerId { get; set; }

        public virtual Package? Package { get; set; }
        public virtual Company? Partner { get; set; }
    }
}
