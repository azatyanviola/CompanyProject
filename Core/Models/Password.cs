using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Password : BaseEntity
    {
        
        public int? UserCompanyId { get; set; }
        public string? Hash { get; set; }
        public string? Salt { get; set; }
        public DateOnly? InsertedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }

        public virtual UserCompany? UserCompany { get; set; }
    }
}
