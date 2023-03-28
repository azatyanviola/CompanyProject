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
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository _repository;

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
        }



        public IEnumerable<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId)
        {
            var departments = _repository.GetDepartmentsByCompanyId(companyId);

            if (departments == null || !departments.Any())
            {
                throw new ArgumentException($"No departments found for Company with ID {companyId}");
            }

            return departments;
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
