using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Benefit : BaseEntity
    {
        public Benefit()
        {
            BenefitTransactions = new HashSet<BenefitTransaction>();
        }

      
        public int? UserCompanyId { get; set; }
        public int? PackageId { get; set; }
        public DateOnly? InsertedDate { get; set; }

        public virtual Package? Package { get; set; }
        public virtual UserCompany? UserCompany { get; set; }
        public virtual ICollection<BenefitTransaction> BenefitTransactions { get; set; }
    }
}
