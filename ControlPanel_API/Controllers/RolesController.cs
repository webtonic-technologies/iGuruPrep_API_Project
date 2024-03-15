using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ControlPanel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IRolesService _rolelService;
        public RolesController(AppDbContext context, IRolesService rolelService)
        {
            _context = context;
            _rolelService = rolelService;
        }
        [HttpGet("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            try
            {
                return new OkObjectResult(new { data = await _rolelService.GetRoles() });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }

        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole(string roleName, string roleCode, int roleNumber)
        {
            try
            {
                return new OkObjectResult(new { data = await _rolelService.AddRole(roleName, roleCode, roleNumber) });
            }
            catch (Exception ex)
            {
                return StatusCode(400, ex.Message.ToString());
            }

        }
        [HttpPost("UpdateRole")]
        public async Task<ActionResult> UpdateRole(Role role)
        {
            try
            {
                if (role.RoleId != 0)
                {
                    _context.Entry(role).State = EntityState.Modified;
                    return new OkObjectResult(new { data = await _rolelService.UpdateRole(role) });

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
