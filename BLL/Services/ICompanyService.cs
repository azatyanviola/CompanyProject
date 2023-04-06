using Core.CompanyModels;
using Core.Models;
using Core.ResponsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface ICompanyService
    {
        /// <summary>
        /// Get all Departments by CompanyId
        /// </summary>
        /// <param name="companyId">A specific CompanyId</param>
        /// <returns>All Departments with Id and Name</returns>
        IList<DepartmentResponsModel> GetDepartmentsByCompanyId(int companyId);



        /// <summary>
        /// Get a Position by CompanyId
        /// </summary>
        /// <param name="companyId">A specific CompanyId</param>
        /// <param name="companyId"></param>
        /// <returns>Position with Id and Name</returns>
        IList<PositionResponseModel> GetPositionByCompanyId(int companyId);


        /// <summary>
        /// Get all Branches by CompanyId
        /// </summary>
        /// <param name="companyId">A specific CompanyId</param>
        /// <returns>All Branches with Id and Name</returns>
        IList<Branch> GetBranchesByCompanyId(int companyId);


        /// <summary>
        /// Get all CompanyUsers 
        /// </summary>
        /// <param name="companyId">specific CompanyId</param>
        /// <param name="searchText">FirstName or LastName</param>
        /// <param name="departmentId">Specific DepartmentId</param>
        /// <param name="branchId">Specific BranchId</param>
        /// <param name="positionId">Specific PositionId</param>
        /// <returns>Users according to filtering result</returns>
        IList<CompanyUserModel> GetUsers(int companyId, string? searchText, int? departmentId, int? branchId, int? positionId);




        /// <summary>
        /// Add new Position
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        int AddPosition(Position position);



        /// <summary>
        /// Add CompanyUser
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userCompany"></param>
        /// <returns></returns>
        int AddUser(User user, UserCompany userCompany);

        /// <summary>
        /// Update UserCompany
        /// </summary>
        /// <param name="user"></param>
        /// <param name="userCompany"></param>
        /// <returns></returns>
        int UpdateUser(User user, UserCompany userCompany);
        
        /// <summary>
        /// Get CompanyUser
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        UserCompany GetUserCompanyById(int id);
    }
}
