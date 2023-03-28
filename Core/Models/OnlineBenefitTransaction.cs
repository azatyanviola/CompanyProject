using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class OnlineBenefitTransaction : BaseEntity
    {
        public int? UserCompanyId { get; set; }
        public decimal? Amount { get; set; }
        public string? Url { get; set; }
        public string? Status { get; set; }
        public DateOnly? InsertedDate { get; set; }

        public virtual UserCompany? UserCompany { get; set; }
    }
}
