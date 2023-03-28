using Core.Models;
using Core.ResponsModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface ICompanyRepository : IRepository<Company>
    {
        IEnumerable<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId);
       
    }
}
