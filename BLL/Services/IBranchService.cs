using Core.Models;
using Core.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBranchService
    {
        IEnumerable<BranchResponsModel> GetBranchesByCompanyId(int companyId);

    }
}