using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IRolesService
    {
        Task<List<Role>> GetRoles();
        Task<Role> GetRoleByID(int roleId);
        Task<Role> AddRole(Role role);        
        Task<Role> UpdateRole(Role role);
    }
}
