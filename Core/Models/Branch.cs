using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public partial class Branch : BaseEntity
    {
        public Branch()
        {
            CompanyBranches = new HashSet<CompanyBranch>();
            UserCompanies = new HashSet<UserCompany>();
        }

        public string Name { get; set; } = null!;
        public int? AddressId { get; set; }


        public virtual Address? Address { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranches { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
