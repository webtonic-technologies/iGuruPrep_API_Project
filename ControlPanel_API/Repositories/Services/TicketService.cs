using ControlPanel_API.DBContext;
using ControlPanel_API.DTOs;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;

namespace ControlPanel_API.Repositories.Services
{
    public class TicketService : ITicketService
    {
        private readonly AppDbContext _context;
        public TicketService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<string> AddTicket(Ticket request)
        {
            try
            {
                var newTicket = new Ticket
                {
                    TicketID = request.TicketID,
                   Boardname = request.Boardname,
                   ClassName = request.ClassName,
                   CourseName = request.CourseName,
                   DateAndTime = request.DateAndTime,
                   MobileNumber = request.MobileNumber,
                   QueryInfo = request.QueryInfo,
                   QueryType = request.QueryType,
                   Status = request.Status,
                   SubjectName = request.SubjectName,
                   TicketNo = request.TicketNo
                };

                _context.tblTicket.Add(newTicket);
                _context.SaveChanges();

                return "Ticket added successfully";
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Ticket>> GetAllTicketsList(GeAllTicketsRequest request)
        {
            try
            {
                var data = _context.tblTicket.Where(x=>x.Boardname == request.Boardname || 
                x.CourseName == request.CourseName ||
                x.ClassName == request.ClassName || x.DateAndTime == request.Today || (x.DateAndTime >= request.StartDate && x.DateAndTime <= request.EndDate)).Select(x => new Ticket
                {
                 DateAndTime = x.DateAndTime,
                 ClassName = x.ClassName,
                 CourseName = x.CourseName,
                 Boardname = x.Boardname,
                 MobileNumber= x.MobileNumber,
                 QueryInfo= x.QueryInfo,
                 QueryType= x.QueryType,
                 Status= x.Status,
                 SubjectName= x.SubjectName,
                 TicketID = x.TicketID,
                 TicketNo = x.TicketNo
                }).ToList();
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new List<Ticket>();
            }
        }
    }
}
