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
    public class BranchService : IBranchService
    {

        private readonly IBranchRepository _repository;

        public BranchService(IBranchRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BranchResponsModel> GetBranchesByCompanyId(int companyId)
        {
            var branches = _repository.GetBranchesByCompanyId(companyId);

            if (branches == null || !branches.Any())
            {
                throw new ArgumentException($"No CompanyBranches found for Company with ID {companyId}");
            }

            return branches;
        }
    }
}