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
    public class BranchController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchController(IBranchService branchService)
        {
            _branchService = branchService;
        }
        /// <summary>
        /// Get Branches with specific CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>

        [HttpGet("{companyId}")]
        public IActionResult GetBranchesByCompanyId(int companyId)
        {
            var branches = _branchService.GetBranchesByCompanyId(companyId);

            if (branches == null || !branches.Any())
            {
                return NotFound();
            }

            return Ok(branches);
        }
    }
}