using Backend.Models;
using Backend.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("{employee_id}")]
        public async Task<IActionResult> GetEmployee(string employee_id)
        {
            var employee = await _employeeService.GetEmployee(employee_id);

            if (employee == null)
            {
                return NotFound(new { message = $"Employee with ID '{employee_id}' not found." });
            }

            return Ok(employee);
        }

        [HttpPost("add")]
        public async Task<ActionResult<bool>> AddEmployee([FromBody] EpEmployee employee)
        {
            var result = await _employeeService.AddEmployee(employee);

            if (result)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500, false);
            }
        }
    }
}
