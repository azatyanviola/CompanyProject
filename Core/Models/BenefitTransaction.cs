using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class BenefitTransaction : BaseEntity
    {
        
        public int? BenefitId { get; set; }
        public decimal? Amount { get; set; }
        public int? PartnerId { get; set; }
        public DateOnly? InsertedDate { get; set; }

        public virtual Benefit? Benefit { get; set; }
        public virtual Company? Partner { get; set; }
    }
}
