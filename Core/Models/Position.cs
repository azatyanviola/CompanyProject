using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Position : BaseEntity
    {
        public Position()
        {
            UserCompanies = new HashSet<UserCompany>();
            CompanyPositions = new HashSet<CompanyPosition>();
        }

       
        public string? Name { get; set; }
       

        
        public virtual ICollection<UserCompany> UserCompanies { get; set; }
        public virtual ICollection<CompanyPosition> CompanyPositions { get; set; }
    
}
}
