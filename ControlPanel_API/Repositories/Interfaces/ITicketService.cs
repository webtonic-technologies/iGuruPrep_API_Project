using ControlPanel_API.DTOs;
using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface ITicketService
    {
        Task<string> AddTicket(Ticket request);
        Task<List<Ticket>> GetAllTicketsList(GeAllTicketsRequest request);
    }
}
