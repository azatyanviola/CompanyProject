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
    public class UserCompanyRepository : Repository<UserCompany>, IUserCompanyRepository
    {

        private readonly DbContext _dbContext;
        public UserCompanyRepository(BenefiticContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
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
    }
}