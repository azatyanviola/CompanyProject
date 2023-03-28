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


    }
}
