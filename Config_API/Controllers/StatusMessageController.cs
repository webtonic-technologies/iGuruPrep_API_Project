// BoardsController.cs
using Config_API.Models;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class StatusMessageController : ControllerBase
{
    private readonly IStatusMessageService _statusMessageService;

    public StatusMessageController(IStatusMessageService statusMessageService)
    {
        _statusMessageService = statusMessageService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateStatusMessage(StatusMessage request)
    {
        try 
        {
            var data = await _statusMessageService.AddUpdateStatusMessage(request);
            if(data != null)
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
    [HttpGet("GetStatusMessage/{StatusId}")]
    public async Task<IActionResult> GetStatusMessageById(int StatusId)
    {
        try
        {
            var data = await _statusMessageService.GetStatusMessageById(StatusId);
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
