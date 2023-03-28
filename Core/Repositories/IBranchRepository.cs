using Core.Models;
using Core.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IBranchRepository : IRepository<Company>
    {
        IEnumerable<BranchResponsModel> GetBranchesByCompanyId(int companyId);

    }
}
