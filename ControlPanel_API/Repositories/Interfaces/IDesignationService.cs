using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IDesignationService 
    {
        Task<List<Designation>> GetDesignationList();
        Task<Designation> AddDesignation(string designationName, string designationCode, int designationNumber);
        Task<Designation> UpdateDesignation(Designation designation);
    }
}
