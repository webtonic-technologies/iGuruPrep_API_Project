using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

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
                return NotFound();
            }

        }
        [HttpGet("GetRoleById/{roleId}")]
        public async Task<IActionResult> GetRoleByID(int roleId)
        {
            try
            {
                return new OkObjectResult(new { data = await _rolelService.GetRoleByID(roleId) });
            }
            catch (Exception ex)
            {
                return NotFound();
            }

        }

        [HttpPost("AddRole")]
        public async Task<ActionResult> AddRole(Role role)
        {
            try
            {
                return new OkObjectResult(new { data = await _rolelService.AddRole(role) });
            }
            catch (Exception ex)
            {
                return new JsonResult("")
                {
                    StatusCode = (int)HttpStatusCode.NotAcceptable
                };
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
                return new JsonResult("")
                {
                    StatusCode = (int)HttpStatusCode.NotAcceptable
                };
            }

        }
    }
}
