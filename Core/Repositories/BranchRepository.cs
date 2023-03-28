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
    public class BranchRepository : Repository<Company>, IBranchRepository
    {

        private readonly DbContext _dbContext;
        public BranchRepository(BenefiticContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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