using Core.CompanyModels;
using Core.Models;
using Core.ResponsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {

        private readonly BenefiticContext _dbContext;
        
        public CompanyRepository(BenefiticContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
           
        }

        public IEnumerable<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId)
        {

            var query = _dbContext.Set<Department>()
                .Where(d => d.CompanyDepartments.Any(cd => cd.CompanyId == companyId && cd.DepartmentId == d.Id))
                 .Select(d => new DepartmentResponsModel
                 {
                     Id = d.Id,
                     Name = d.Name,
                 });

            return query.ToList();
        }


        public IEnumerable<PositionResponseModel> GetPositionByCompanyId(int companyId)
        {

            var query = _dbContext.Set<Position>()
                .Where(p => p.CompanyPositions.Any(cp => cp.CompanyId == companyId && cp.PositionId == p.Id))
                .Select(p => new PositionResponseModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return query.ToList();
        }


        public IEnumerable<Branch> GetBranchesByCompanyId(int companyId)
        {
            //var query = _dbContext.Set<Branch>()
            //    .Where(b => b.CompanyBranches.Any(cb => cb.CompanyId == companyId && cb.BranchId == b.Id))
            //    .Select(b => new BranchResponsModel
            //    {
            //        Id = b.Id,
            //        Name = b.Name
            //    });
            var query = from b in _dbContext.Branches
                        where (from cb in _dbContext.CompanyBranches
                               where cb.CompanyId == companyId
                               select cb.BranchId).Contains(b.Id)
                        select b;


            return query.ToList();
        }
       

        public IEnumerable<CompanyUserModel> GetUsers(int companyId, string? searchText, int? departmentId, int? branchId, int? positionId)
        {
           
            var query = from uc in _dbContext.UserCompanies
                        join b in _dbContext.Companies on uc.BranchId equals b.Id
                        join u in _dbContext.Users on uc.UserId equals u.Id
                        join cb in _dbContext.CompanyBranches on companyId equals cb.CompanyId
                        
                        where
                          (string.IsNullOrEmpty(searchText) ||
                          (uc.FirstName + " " + uc.LastName).Contains(searchText) ||
                          (u.PhoneCode.Code + u.PhoneNumber).Contains(searchText)) &&
                          (branchId == 0 || branchId == null || uc.BranchId == branchId) &&
                          // uc.BranchId == cb.BranchId &&
                          (departmentId == null || departmentId.Value == 0 || uc.DepartmentId == departmentId) &&
                          (positionId == null || positionId.Value == 0 || uc.PositionId == positionId)

                        select new CompanyUserModel
                        {
                            Id = uc.Id,
                            FirstName = uc.FirstName,
                            LastName = uc.LastName,
                            Branch = b.Name,
                            Department = uc.Department.Name,
                            Position = uc.Position.Name,
                            Email = uc.Email,
                            Phone = u.PhoneCode.Code + u.PhoneNumber,
                            BirthDate = uc.BirthDate
                        };

                     return query.ToList();
         }



        public int AddPosition(Position position)
        {
            _dbContext.Positions.Add(position);
            _dbContext.SaveChanges();
            return position.Id;
        }
            public int AddUser(User user, UserCompany userCompany)
        {

            _dbContext.Add(user);
            _dbContext.SaveChanges();
            userCompany.UserId = user.Id;
            _dbContext.Add(userCompany);
            _dbContext.SaveChanges();

            return user.Id;
           

        }


        public int UpdateUser(User user, UserCompany userCompany)
        {
           
            
            _dbContext.UserCompanies.Update(userCompany);
            _dbContext.SaveChanges();
            userCompany.UserId = user.Id;
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();

            return user.Id;

        }




        public User GetUserById(int id)
        {
            return _dbContext.Users.FirstOrDefault(u => u.Id == id);
        }

        public UserCompany GetUserCompanyById(int id)
        {
            return _dbContext.UserCompanies.FirstOrDefault(uc => uc.Id == id);
        }
    } 
}

