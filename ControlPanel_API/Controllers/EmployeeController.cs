using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ControlPanel_API.Controllers
{
    [Route("iGuru/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IEmployeeService _employeeService;
        public EmployeeController(AppDbContext context, IEmployeeService employeeService)
        {
            _context = context;
            _employeeService = employeeService;
        }


        [HttpGet("GetEmployee")]
        public IActionResult GetEmployee(string role, string designation)
        {
            try
            {
                return new OkObjectResult(new { data = _employeeService.GetEmployeList(role, designation) });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }

        [HttpPost("AddEmployee")]
        public IActionResult AddEmployee(Employee employee)
        {
            try
            {
                return new OkObjectResult(new { data = _employeeService.AddEmployee(employee) });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }
    }
}
