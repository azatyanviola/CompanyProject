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
        /// <summary>
        /// Get all Departments by CompanyId
        /// </summary>
        /// <param name="companyId">A specific CompanyId</param>
        /// <returns>All Departments with Id and Name</returns>
        IEnumerable<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId);


        /// <summary>
        /// Get all Branches by CompanyId
        /// </summary>
        /// <param name="companyId">A specific CompanyId</param>
        /// <returns>All Branches with Id and Name</returns>
        IEnumerable<BranchResponsModel> GetBranchesByCompanyId(int companyId);

        /// <summary>
        /// Get a Position by CompanyId
        /// </summary>
        /// <param name="companyId">A specific CompanyId</param>
        /// <param name="companyId"></param>
        /// <returns>Position with Id and Name</returns>
        IEnumerable<PositionResponseModel> GetPositionByCompanyId(int companyId);

    }
}
