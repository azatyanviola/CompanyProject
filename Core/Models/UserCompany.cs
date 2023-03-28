using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class UserCompany : BaseEntity
    {
        public UserCompany()
        {
            Benefits = new HashSet<Benefit>();
            OnlineBenefitTransactions = new HashSet<OnlineBenefitTransaction>();
            Packages = new HashSet<Package>();
            Passwords = new HashSet<Password>();
            UserCompanyRoles = new HashSet<UserCompanyRole>();
        }

        public int? UserId { get; set; }
        public int? CompanyId { get; set; }
        public int? PositionId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateOnly? BirthDate { get; set; }
        public int? AddressId { get; set; }
        public DateOnly? InsertedDate { get; set; }
        public DateOnly? UpdatedDate { get; set; }

        public virtual Address? Address { get; set; }
        public virtual Company? Company { get; set; }
        public virtual Position? Position { get; set; }
        public virtual User? User { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<OnlineBenefitTransaction> OnlineBenefitTransactions { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<UserCompanyRole> UserCompanyRoles { get; set; }
    }
}
