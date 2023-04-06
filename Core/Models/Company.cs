using System;
using System.Collections.Generic;

namespace Core.Models
{
    public partial class Company : BaseEntity
    {
        public Company()
        {
            BenefitTransactions = new HashSet<BenefitTransaction>();
            CompanyBranchBranches = new HashSet<CompanyBranch>();
            CompanyBranchCompanies = new HashSet<CompanyBranch>();
            CompanyDepartments = new HashSet<CompanyDepartment>();
            CompanyIndustries = new HashSet<CompanyIndustry>();
            CompanyTypes = new HashSet<CompanyType>();
            PackagePartners = new HashSet<PackagePartner>();
            PartnerServices = new HashSet<PartnerService>();
           
            CompanyPositions = new HashSet<CompanyPosition>();
        }

       
        public string Name { get; set; } = null!;
        
        public int? PhoneCodeId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string TaxNumber { get; set; } = null!;
        public string AccountNumber { get; set; } = null!;
        public string WebSiteUrl { get; set; } = null!;
        public string LogoPath { get; set; } = null!;
        public string? Description { get; set; }

        
        public virtual PhoneCode? PhoneCode { get; set; }
        public virtual ICollection<BenefitTransaction> BenefitTransactions { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranchBranches { get; set; }
        public virtual ICollection<CompanyBranch> CompanyBranchCompanies { get; set; }
        public virtual ICollection<CompanyDepartment> CompanyDepartments { get; set; }
        public virtual ICollection<CompanyIndustry> CompanyIndustries { get; set; }
        public virtual ICollection<CompanyType> CompanyTypes { get; set; }
        public virtual ICollection<PackagePartner> PackagePartners { get; set; }
        public virtual ICollection<PartnerService> PartnerServices { get; set; }
        
        public virtual ICollection<CompanyPosition> CompanyPositions { get; set; }
    }
}
