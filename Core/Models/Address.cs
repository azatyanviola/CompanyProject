using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Address : BaseEntity
    {
        public Address()
        {

            Companies = new HashSet<Company>();
            UserCompanies = new HashSet<UserCompany>();
        }

      
        public string? Address1 { get; set; }
        public int? CityId { get; set; }

        public virtual City? City { get; set; }
        public virtual ICollection<Company> Companies { get; set; }
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
    }
}
