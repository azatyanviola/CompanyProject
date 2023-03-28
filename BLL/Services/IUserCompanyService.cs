using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.ResponsModels;

namespace BLL.Services
{
    public interface IUserCompanyService
    {
        IEnumerable<PositionResponseModel> GetPositionByCompanyId(int companyId);
    }
}
