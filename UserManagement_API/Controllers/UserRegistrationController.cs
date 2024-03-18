using Microsoft.AspNetCore.Mvc;
using UserManagement_API.DTOs;
using UserManagement_API.Models;
using UserManagement_API.Repositories.Interfaces;

namespace UserManagement_API.Controllers
{
    [ApiController]
    [Route("iGuru/[controller]")]
    public class UserRegistrationController : ControllerBase
    {
        private readonly IRegistrationService _registrationService;

        public UserRegistrationController(IRegistrationService registrationService)
        {
            _registrationService = registrationService;
        }

        [HttpPost]
        public async Task<IActionResult> UserRegistration(RegistrationDtocs request)
        {
            try
            {
                var data = await _registrationService.UserRegistration(request);
                if (data != null)
                {
                    return Ok(data);

                }
                else
                {
                    return BadRequest("Bad Request");
                }

            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }

        }
    }
}
