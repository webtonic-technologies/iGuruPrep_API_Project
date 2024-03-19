using ControlPanel_API.DBContext;
using ControlPanel_API.DTOs;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using ControlPanel_API.Repositories.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ControlPanel_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedBackService _feedbackService;
        public FeedbackController(IFeedBackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpPost("AddFeedback")]
        public async Task<IActionResult> AddFeedback(Feedback request)
        {
            try
            {
                var data = await _feedbackService.AddFeedBack(request);
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
        [HttpPost("GetAllFeedback")]
        public async Task<IActionResult> GetAllFeedback(GetAllFeedbackRequest request)
        {
            try
            {
                var data = await _feedbackService.GetAllFeedBackList(request);
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
