using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Repositories;
using BLL.Services;
using System.Collections.Generic;
using System.ComponentModel.Design;
using CompanyProject.RequestModels;
using AutoMapper;
using Core.ResponsModels;
using CompanyProject.ResponseModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;
        private readonly IMapper _mapper;

        public CompanyController(ICompanyService companyService, IMapper mapper)
        {
            _companyService = companyService;
            _mapper = mapper;
        }

        /// <summary>
        /// Get Departments by specific CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        [HttpGet("{companyId}")]
        public IActionResult Departments(int companyId)
        {
            var departments = _companyService.GetDepartmentsByCompanyId(companyId);

            if (departments == null || !departments.Any())
            {
                return NotFound();
            }

            return Ok(departments);
        }



        /// <summary>
        /// Get Position by specific CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("{companyId}")]
        public IActionResult Position(int companyId)
        {
            var position = _companyService.GetPositionByCompanyId(companyId);

            if (position == null || !position.Any())
            {
                return NotFound();
            }

            return Ok(position);
        }



        /// <summary>
        /// Get Branches with specific CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        [HttpGet("{companyId}")]
        public IActionResult Branches(int companyId)
        {
            var branches = _companyService.GetBranchesByCompanyId(companyId);

            if (branches == null || !branches.Any())
            {
                return NotFound();
            }

            return Ok(branches);
        }


        /// <summary>
        /// Get all Company users
        /// </summary>
        /// <param name="model">CompanyUsers Request Model</param>
        /// <returns>Company</returns>
        [HttpPost]
        public IActionResult GetUsers([FromBody] CompanyUsersRequestModel model)
        {
            var users = _companyService.GetUsers(model.CompanyId, model.SearchText, model.BranchId, model.DepartmentId, model.PositionId);


            return Ok(users);
        }

        /// <summary>
        /// Add CompanyUser
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>

        [HttpPost]
        public IActionResult AddUser([FromBody] CompanyUserAddModel model)
        {
            var user = _mapper.Map<User>(model);
            var positionId = model.PositionId; 
            if (!string.IsNullOrEmpty(model.PositionName))

            {
                var position = _mapper.Map<Position>(model);
                position.Name = model.PositionName;
                positionId = _companyService.AddPosition(position);
            }
            
                var userCompany = _mapper.Map<UserCompany>(model);
                userCompany.PositionId = positionId;
                var addedUserId = _companyService.AddUser(user, userCompany);
           
                return Ok(new { addedUserId });
            
        }


     
      /// <summary>
      /// Update the UsrCompany
      /// </summary>
      /// <param name="model"></param>
      /// <returns></returns>

        [HttpPut]
        public IActionResult UpdateUser( [FromBody] CompanyUserUpdateModel model)
        {
           

           var user = _mapper.Map<User>(model);

            var positionId = model.PositionId;
            if (!string.IsNullOrEmpty(model.PositionName))

            {
                var position = _mapper.Map<Position>(model);
                position.Name = model.PositionName;
                positionId = _companyService.AddPosition(position);
            }



            var excistingUserCompany = _companyService.GetUserCompanyById(model.Id);

            if (excistingUserCompany == null)
            {
                return NotFound();
            }


            var userCompany = excistingUserCompany;
 
            userCompany.FirstName = model.FirstName;
            userCompany.LastName = model.LastName;
            userCompany.BranchId = model.BranchId;
            userCompany.DepartmentId = model.DepartmentId;
            userCompany.PositionId = positionId;
            userCompany.Email = model.Email;
            userCompany.BirthDate = DateTime.SpecifyKind(model.BirthDate, DateTimeKind.Utc);

            
            _companyService.UpdateUser(user, userCompany);

            return Ok("The user updated successfully");
        }

        /// <summary>
        /// Get Company Data
        /// </summary>
        /// <param name="companyId">CompanyId</param>
        /// <returns></returns>
        [HttpGet("{companyId}")]
        public IActionResult CompanyFilterData(int companyId)
        {

            var companyData = new CompanyUsersFilterData
            {
                Positions = _companyService.GetPositionByCompanyId(companyId),
                Departments = _companyService.GetDepartmentsByCompanyId(companyId),
                Branches = _companyService.GetBranchesByCompanyId(companyId)
            };

            return Ok(companyData);
        }
    }
}
