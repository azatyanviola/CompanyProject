using Core.Models;
using Core.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Repositories
{
    public interface IUserCompanyRepository : IRepository<UserCompany>
    {
        IEnumerable<PositionResponseModel> GetPositionByCompanyId(int companyId);
    }
}
