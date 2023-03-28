using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Repositories;
using BLL.Services;
using System.Collections.Generic;
using System.ComponentModel.Design;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CompanyProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
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

    }
}
