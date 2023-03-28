using Core.Models;
using Core.ResponsModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {

        private readonly DbContext _dbContext;
        public CompanyRepository(BenefiticContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId)
        {
    
            var query = _dbContext.Set<Department>()
                .Where(d => d.CompanyDepartments.Any(cd => cd.CompanyId == companyId && cd.DepartmentId == d.Id))
                 .Select (d => new DepartmentResponsModel
                 {
                     Id = d.Id,
                     Name = d.Name,
                 });

            return query.ToList();
        }


        public IEnumerable<PositionResponseModel> GetPositionByCompanyId(int companyId)
        {

            var query = _dbContext.Set<Position>()
                .Where(p => p.UserCompanies.Any(uc => uc.CompanyId == companyId && uc.PositionId == p.Id))
                .Select(p => new PositionResponseModel
                {
                    Id = p.Id,
                    Name = p.Name
                });

            return query.ToList();
        }


        public IEnumerable<BranchResponsModel> GetBranchesByCompanyId(int companyId)
        {
            var query = _dbContext.Set<Company>()
                .Where(c => c.CompanyBranchBranches.Any(cb => cb.CompanyId == companyId && cb.BranchId == c.Id))
                .Select(c => new BranchResponsModel
                {
                    Id = c.Id,
                    Name = c.Name
                });


            return query.ToList();
        }

    }
}
