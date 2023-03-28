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
      



        //public IEnumerable<Department> GetDepart()

        //{
        //   return _repository.GetAll();
        //}

        //public IEnumerable<Department> GetDepById(int id)

        //{
        //    return _repository.GetAll();
        //}
    }
}
