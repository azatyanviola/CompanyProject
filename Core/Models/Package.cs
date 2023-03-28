using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Package : BaseEntity
    {
        public Package()
        {
            Benefits = new HashSet<Benefit>();
            PackagePartners = new HashSet<PackagePartner>();
        }

       
        public string? Name { get; set; }
        public string? Purpose { get; set; }
        public decimal? Budget { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public int? PackageStatusId { get; set; }
        public int? UserCompanyId { get; set; }
        public bool? IsRepeatable { get; set; }
        public DateOnly? InsertedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }

        public virtual PackageStatus? PackageStatus { get; set; }
        public virtual UserCompany? UserCompany { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<PackagePartner> PackagePartners { get; set; }
    }
}
