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
    public class TicketController : ControllerBase
    {
        private readonly ITicketService _ticketService;
        public TicketController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [HttpPost("AddTicket")]
        public async Task<IActionResult> AddTicket(Ticket request)
        {
            try
            {
                var data = await _ticketService.AddTicket(request);
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
        [HttpPost("GetAllTickets")]
        public async Task<IActionResult> GetAllTickets(GeAllTicketsRequest request)
        {
            try
            {
                var data = await _ticketService.GetAllTicketsList(request);
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
