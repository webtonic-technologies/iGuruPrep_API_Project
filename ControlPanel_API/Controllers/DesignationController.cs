using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace ControlPanel_API.Controllers
{
    [Route("iGuru/[controller]")]
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
                return new JsonResult("Records Not Found")
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
            }

        }
        [HttpGet("GetDesignationById/{DesgnID}")]
        public async Task<IActionResult> GetDesignationByID(int DesgnID)
        {
            try
            {
                return new OkObjectResult(new { data = await _designationService.GetDesignationByID(DesgnID) });
            }
            catch (Exception ex)
            {
                return new JsonResult("Records Not Found")
                {
                    StatusCode = (int)HttpStatusCode.NotFound
                };
            }

        }

        [HttpPost("AddDesignation")]
        public async Task<IActionResult> AddDesignation(Designation designation)
        {
            try
            {
                return new OkObjectResult(new { data = await _designationService.AddDesignation(designation) });
            }
            catch (Exception ex)
            {
                return new JsonResult("Records Not Found")
                {
                    StatusCode = (int)HttpStatusCode.NotAcceptable
                };
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
                return new JsonResult("Records Not Found")
                {
                    StatusCode = (int)HttpStatusCode.NotAcceptable
                };
            }

        }
    }
}
