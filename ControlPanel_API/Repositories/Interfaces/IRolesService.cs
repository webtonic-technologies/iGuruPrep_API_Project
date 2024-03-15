using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IRolesService
    {
        Task<List<Role>> GetRoles();
        Task<Role> AddRole(string roleName, string roleCode, int roleNumber);
        
        Task<Role> UpdateRole(Role role);
    }
}
