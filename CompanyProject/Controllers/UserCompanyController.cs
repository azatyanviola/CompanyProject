using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Core.Repositories;
using BLL.Services;
using System.Collections.Generic;
using System.ComponentModel.Design;

namespace CompanyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCompanyController : ControllerBase
    {
        private readonly IUserCompanyService _userCompanyService;

        public UserCompanyController(IUserCompanyService userCompanyService)
        {
            _userCompanyService = userCompanyService;
        }

        /// <summary>
        /// Get Position by specific CompanyId
        /// </summary>
        /// <param name="companyId"></param>
        /// <returns></returns>
        [HttpGet("{companyId}")]
        public IActionResult GetPositionsByCompanyId(int companyId)
        {
            var position = _userCompanyService.GetPositionByCompanyId(companyId);

            if (position == null || !position.Any())
            {
                return NotFound();
            }

            return Ok(position);
        }
    }
}
