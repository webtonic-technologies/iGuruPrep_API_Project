using ControlPanel_API.DBContext;
using ControlPanel_API.Models;
using ControlPanel_API.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ControlPanel_API.Repositories.Services
{
    public class DesignationService : IDesignationService
    {
        private readonly AppDbContext _context;
        public DesignationService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<Designation> AddDesignation(Designation request)
        {
            try
            {
                var designation = new Designation
                {
                    DesignationName = request.DesignationName,
                    DesgnCode = request.DesgnCode,
                    DesignationNumber = request.DesignationNumber,
                    Status = true,
                };

                _context.tblDesignation.Add(designation);
                _context.SaveChanges();

                return await Task.FromResult(designation);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<Designation> UpdateDesignation(Designation designation)
        {
            try
            {
                var data = _context.tblDesignation.Where(x => x.DesgnID == designation.DesgnID).FirstOrDefault();
                if (data != null)
                {
                    data.DesgnID = designation.DesgnID;
                    data.DesgnCode = designation.DesgnCode;
                    data.DesignationNumber = designation.DesignationNumber;
                    data.Status = designation.Status;

                    _context.tblDesignation.Update(designation);
                    _context.SaveChanges();
                    _context.Entry(data).State = EntityState.Detached;
                    return await Task.FromResult(designation);

                }

                return null;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<List<Designation>> GetDesignationList()
        {
            try
            {
                return _context.tblDesignation.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public Task<Designation> GetDesignationByID(int DesgnID)
        {
            try
            {

                var data = _context.tblDesignation.Where(x => x.DesgnID == DesgnID).FirstOrDefault();
                if (data != null)
                {
                    return Task.FromResult(data);
                }
                else
                {
                    return Task.FromResult<Designation>(null);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
