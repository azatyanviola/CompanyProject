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
        public int? BranchId { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime? BirthDate { get; set; }
      
        public DateTime? InsertedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }

        
        public virtual Department? Department { get; set; }
        public virtual Position? Position { get; set; }
        public virtual User? User { get; set; }
        public virtual Branch? Branch { get; set; }
        public virtual ICollection<Benefit> Benefits { get; set; }
        public virtual ICollection<OnlineBenefitTransaction> OnlineBenefitTransactions { get; set; }
        public virtual ICollection<Package> Packages { get; set; }
        public virtual ICollection<Password> Passwords { get; set; }
        public virtual ICollection<UserCompanyRole> UserCompanyRoles { get; set; }
    }
}
