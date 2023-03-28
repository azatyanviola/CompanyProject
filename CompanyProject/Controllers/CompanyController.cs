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
    [Route("api/[controller]")]
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
        public IActionResult GetDepartmentsByCompanyId(int companyId)
        {
            var departments = _companyService.GetDepartmentsByCompanyId(companyId);

            if (departments == null || !departments.Any())
            {
                return NotFound();
            }

            return Ok(departments);
        }

    }
}
