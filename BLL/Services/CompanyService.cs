using Core.CompanyModels;
using Core.Models;
using Core.Repositories;
using Core.ResponsModels;
using Microsoft.EntityFrameworkCore;

namespace BLL.Services
{
    public class CompanyService : ICompanyService
    {

        private readonly ICompanyRepository _repository;
       

        public CompanyService(ICompanyRepository repository)
        {
            _repository = repository;
           
        }



        public IList<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId)
        {
            var departments = _repository.GetDepartmentsByCompanyId(companyId).ToList();

            if (departments == null || !departments.Any())
            {
                throw new ArgumentException($"No departments found for Company with ID {companyId}");
            }

            return departments;
        }



      
        public IList<PositionResponseModel> GetPositionByCompanyId(int companyId)
        {
            var position = _repository.GetPositionByCompanyId(companyId).ToList();

            if (position == null || !position.Any())
            {
                throw new ArgumentException($"No position found for Company with ID {companyId}");
            }

            return position;
        }



    
        public IList<Branch> GetBranchesByCompanyId(int companyId)
        {
            var branches = _repository.GetBranchesByCompanyId(companyId).ToList();

            if (branches == null || !branches.Any())
            {
                throw new ArgumentException($"No CompanyBranches found for Company with ID {companyId}");
            }

            return branches;
        }



        public IList<CompanyUserModel> GetUsers(int companyId, string? searchText, int? departmentId, int? branchId, int? positionId)
         {
            return _repository.GetUsers(companyId, searchText, departmentId, branchId, positionId).ToList();

           
        }



        public int AddPosition(Position position)
        {
            return _repository.AddPosition(position);

        }

        public int AddUser(User user, UserCompany userCompany)
        {
            return _repository.AddUser(user,  userCompany);

        }

        public int UpdateUser(User user, UserCompany userCompany)
        {
           
            return _repository.UpdateUser(user, userCompany);

        }



        public UserCompany GetUserCompanyById(int id)
        {
            return _repository.GetUserCompanyById(id);
        }
    }
}
