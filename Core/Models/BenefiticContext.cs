using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Core.Models
{
    public partial class BenefiticContext : DbContext
    {
        public BenefiticContext()
        {
        }

        public BenefiticContext(DbContextOptions<BenefiticContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Benefit> Benefits { get; set; } = null!;
        public virtual DbSet<BenefitTransaction> BenefitTransactions { get; set; } = null!;
        public virtual DbSet<City> Cities { get; set; } = null!;
        public virtual DbSet<Company> Companies { get; set; } = null!;
        public virtual DbSet<CompanyBranch> CompanyBranches { get; set; } = null!;
        public virtual DbSet<CompanyDepartment> CompanyDepartments { get; set; } = null!;
        public virtual DbSet<CompanyIndustry> CompanyIndustries { get; set; } = null!;
        public virtual DbSet<CompanyType> CompanyTypes { get; set; } = null!;
        public virtual DbSet<Country> Countries { get; set; } = null!;
        public virtual DbSet<Department> Departments { get; set; } = null!;
        public virtual DbSet<Industry> Industries { get; set; } = null!;
        public virtual DbSet<OnlineBenefitTransaction> OnlineBenefitTransactions { get; set; } = null!;
        public virtual DbSet<Package> Packages { get; set; } = null!;
        public virtual DbSet<PackagePartner> PackagePartners { get; set; } = null!;
        public virtual DbSet<PackageStatus> PackageStatuses { get; set; } = null!;
        public virtual DbSet<PartnerService> PartnerServices { get; set; } = null!;
        public virtual DbSet<Password> Passwords { get; set; } = null!;
        public virtual DbSet<PhoneCode> PhoneCodes { get; set; } = null!;
        public virtual DbSet<Position> Positions { get; set; } = null!;
        public virtual DbSet<Region> Regions { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Type> Types { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserCompany> UserCompanies { get; set; } = null!;
        public virtual DbSet<UserCompanyRole> UserCompanyRoles { get; set; } = null!;
        public virtual DbSet<UserRole> UserRoles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseNpgsql("Host=localhost;Database=Benefitic;User Id=postgres;Password=admin;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("Addresses", "maindata");

                entity.Property(e => e.Address1)
                    .HasMaxLength(200)
                    .HasColumnName("Address");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("Addresses_CityId_fkey");
            });

            modelBuilder.Entity<Benefit>(entity =>
            {
                entity.ToTable("Benefits", "maindata");

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.Benefits)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("Benefits_PackageId_fkey");

                entity.HasOne(d => d.UserCompany)
                    .WithMany(p => p.Benefits)
                    .HasForeignKey(d => d.UserCompanyId)
                    .HasConstraintName("Benefits_UserCompanyId_fkey");
            });

            modelBuilder.Entity<BenefitTransaction>(entity =>
            {
                entity.ToTable("BenefitTransactions", "maindata");

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("now()");

                entity.HasOne(d => d.Benefit)
                    .WithMany(p => p.BenefitTransactions)
                    .HasForeignKey(d => d.BenefitId)
                    .HasConstraintName("BenefitTransactions_BenefitId_fkey");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.BenefitTransactions)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("BenefitTransactions_PartnerId_fkey");
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("Cities", "maindata");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Region)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.RegionId)
                    .HasConstraintName("Cities_RegionId_fkey");
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Companies", "auth");

                entity.Property(e => e.AccountNumber).HasMaxLength(200);

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.LogoPath).HasMaxLength(1000);

                entity.Property(e => e.Name).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(200);

                entity.Property(e => e.TaxNumber).HasMaxLength(200);

                entity.Property(e => e.WebSiteUrl).HasMaxLength(1000);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("Companies_AddressId_fkey");

                entity.HasOne(d => d.PhoneCode)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.PhoneCodeId)
                    .HasConstraintName("Companies_PhoneCodeId_fkey");
            });

            modelBuilder.Entity<CompanyBranch>(entity =>
            {
                entity.ToTable("CompanyBranches", "maindata");

                entity.HasOne(d => d.Branch)
                    .WithMany(p => p.CompanyBranchBranches)
                    .HasForeignKey(d => d.BranchId)
                    .HasConstraintName("CompanyBranches_BranchId_fkey");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyBranchCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("CompanyBranches_CompanyId_fkey");
            });

            modelBuilder.Entity<CompanyDepartment>(entity =>
            {
                entity.ToTable("CompanyDepartments", "maindata");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyDepartments)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("CompanyDepartments_CompanyId_fkey");

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.CompanyDepartments)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("CompanyDepartments_DepartmentId_fkey");
            });

            modelBuilder.Entity<CompanyIndustry>(entity =>
            {
                entity.ToTable("CompanyIndustries", "maindata");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyIndustries)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("CompanyIndustries_CompanyId_fkey");

                entity.HasOne(d => d.Industry)
                    .WithMany(p => p.CompanyIndustries)
                    .HasForeignKey(d => d.IndustryId)
                    .HasConstraintName("CompanyIndustries_IndustryId_fkey");
            });

            modelBuilder.Entity<CompanyType>(entity =>
            {
                entity.ToTable("CompanyTypes", "maindata");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.CompanyTypes)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("CompanyTypes_CompanyId_fkey");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CompanyTypes)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("CompanyTypes_TypeId_fkey");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("Countries", "maindata");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.ToTable("Departments", "maindata");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<Industry>(entity =>
            {
                entity.ToTable("Industries", "maindata");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            modelBuilder.Entity<OnlineBenefitTransaction>(entity =>
            {
                entity.ToTable("OnlineBenefitTransactions", "maindata");

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.Url).HasMaxLength(200);

                entity.HasOne(d => d.UserCompany)
                    .WithMany(p => p.OnlineBenefitTransactions)
                    .HasForeignKey(d => d.UserCompanyId)
                    .HasConstraintName("OnlineBenefitTransactions_UserCompanyId_fkey");
            });

            modelBuilder.Entity<Package>(entity =>
            {
                entity.ToTable("Packages", "maindata");

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.IsRepeatable).HasDefaultValueSql("false");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Purpose).HasMaxLength(100);

                entity.HasOne(d => d.PackageStatus)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.PackageStatusId)
                    .HasConstraintName("Packages_PackageStatusId_fkey");

                entity.HasOne(d => d.UserCompany)
                    .WithMany(p => p.Packages)
                    .HasForeignKey(d => d.UserCompanyId)
                    .HasConstraintName("Packages_UserCompanyId_fkey");
            });

            modelBuilder.Entity<PackagePartner>(entity =>
            {
                entity.ToTable("PackagePartners", "maindata");

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackagePartners)
                    .HasForeignKey(d => d.PackageId)
                    .HasConstraintName("PackagePartners_PackageId_fkey");

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.PackagePartners)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("PackagePartners_PartnerId_fkey");
            });

            modelBuilder.Entity<PackageStatus>(entity =>
            {
                entity.ToTable("PackageStatuses", "maindata");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<PartnerService>(entity =>
            {
                entity.ToTable("PartnerServices", "maindata");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.PartnerServices)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("PartnerServices_CompanyId_fkey");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.PartnerServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("PartnerServices_ServiceId_fkey");
            });

            modelBuilder.Entity<Password>(entity =>
            {
                entity.ToTable("Passwords", "auth");

                entity.Property(e => e.Hash).HasMaxLength(500);

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.Salt).HasMaxLength(100);

                entity.HasOne(d => d.UserCompany)
                    .WithMany(p => p.Passwords)
                    .HasForeignKey(d => d.UserCompanyId)
                    .HasConstraintName("Passwords_UserCompanyId_fkey");
            });

            modelBuilder.Entity<PhoneCode>(entity =>
            {
                entity.ToTable("PhoneCodes", "maindata");

                entity.Property(e => e.Code).HasMaxLength(15);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.ToTable("Positions", "maindata");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Department)
                    .WithMany(p => p.Positions)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("Positions_DepartmentId_fkey");
            });

            modelBuilder.Entity<Region>(entity =>
            {
                entity.ToTable("Regions", "maindata");

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Regions)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("Regions_CountryId_fkey");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Services", "maindata");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(200);
            });

            modelBuilder.Entity<Type>(entity =>
            {
                entity.ToTable("Types", "auth");

                entity.Property(e => e.Type1)
                    .HasMaxLength(100)
                    .HasColumnName("Type");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users", "auth");

                entity.Property(e => e.PhoneNumber).HasMaxLength(200);

                entity.Property(e => e.VerificationCode).HasMaxLength(6);

                entity.HasOne(d => d.PhoneCode)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.PhoneCodeId)
                    .HasConstraintName("Users_PhoneCodeId_fkey");
            });

            modelBuilder.Entity<UserCompany>(entity =>
            {
                entity.ToTable("UserCompanies", "auth");

                entity.Property(e => e.Email).HasMaxLength(500);

                entity.Property(e => e.FirstName).HasMaxLength(200);

                entity.Property(e => e.InsertedDate).HasDefaultValueSql("now()");

                entity.Property(e => e.LastName).HasMaxLength(200);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("UserCompanies_AddressId_fkey");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("UserCompanies_CompanyId_fkey");

                entity.HasOne(d => d.Position)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.PositionId)
                    .HasConstraintName("UserCompanies_PositionId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserCompanies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("UserCompanies_UserId_fkey");
            });

            modelBuilder.Entity<UserCompanyRole>(entity =>
            {
                entity.ToTable("UserCompanyRoles", "auth");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserCompanyRoles)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("UserCompanyRoles_RoleId_fkey");

                entity.HasOne(d => d.UserCompany)
                    .WithMany(p => p.UserCompanyRoles)
                    .HasForeignKey(d => d.UserCompanyId)
                    .HasConstraintName("UserCompanyRoles_UserCompanyId_fkey");
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRoles", "auth");

                entity.Property(e => e.Name).HasMaxLength(100);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
