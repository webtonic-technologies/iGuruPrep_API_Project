using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IDesignationService 
    {
        Task<List<Designation>> GetDesignationList();
        Task<Designation> GetDesignationByID(int DesgnID);
        Task<Designation> AddDesignation(Designation designation);
        Task<Designation> UpdateDesignation(Designation designation);
    }
}
