using System;
using EmployeeBusinessLogic.Interface;
using Entities.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("memberId")]
        [Authorize]
        public IActionResult GetByMemberId(string memberId)
        {
            try
            {
                EmployeeResponse employeeResponse = _employeeService.GetEmployeeByMemberId(memberId);
                return Ok(employeeResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("email")]
        public IActionResult GetByMemberEmail(string email)
        {
            try
            {
                EmployeeResponse employeeResponse = _employeeService.GetEmployeeByEmail(email);
                return Ok(employeeResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("phone")]
        public IActionResult GetByMemberPhone(string phone)
        {
            try
            {
                EmployeeResponse employeeResponse = _employeeService.GetEmployeeByPhone(phone);
                return Ok(employeeResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
