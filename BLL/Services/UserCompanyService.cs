using Core.Models;
using Core.Repositories;
using Core.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserCompanyService : IUserCompanyService
    {

        private readonly IUserCompanyRepository _repository;

        public UserCompanyService(IUserCompanyRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<PositionResponseModel> GetPositionByCompanyId(int companyId)
        {
            var position = _repository.GetPositionByCompanyId(companyId);

            if (position == null || !position.Any())
            {
                throw new ArgumentException($"No position found for Company with ID {companyId}");
            }

            return position;
        }
    }
}