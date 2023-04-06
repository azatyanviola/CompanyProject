using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class User : BaseEntity
    {
        public User()
        {
            UserCompanies = new HashSet<UserCompany>();
        }

       
        public int? PhoneCodeId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public DateTime? ExpirationDate { get; set; }
        public string? VerificationCode { get; set; }

        public virtual PhoneCode? PhoneCode { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
