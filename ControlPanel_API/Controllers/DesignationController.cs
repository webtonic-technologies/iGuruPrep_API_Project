using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using ControlPanel_API.Repositories.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControlPanel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DesignationController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IDesignationService _designationService;
        public DesignationController(AppDbContext context, IDesignationService designationService)
        {
            _context = context;
            _designationService =designationService ;
        }

        [HttpGet("GetDesignation")]
        public async Task<IActionResult> GetDesignation()
        {
            try
            {
                return new OkObjectResult(new { data = await _designationService.GetDesignationList() });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }

        [HttpPost("AddDesignation")]
        public async Task<IActionResult> AddDesignation(string designationName, string designationCode, int designationNumber)
        {
            try
            {
                return new OkObjectResult(new { data = await _designationService.AddDesignation(designationName, designationCode, designationNumber) });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }
        [HttpPost("UpdateDesignation")]
        public async Task<ActionResult> UpdateDesignation(Designation designation)
        {
            try
            {
                if (designation.DesgnID != 0)
                {
                    _context.Entry(designation).State = EntityState.Modified;
                    return new OkObjectResult(new { data = await _designationService.UpdateDesignation(designation) });

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }
    }
}
