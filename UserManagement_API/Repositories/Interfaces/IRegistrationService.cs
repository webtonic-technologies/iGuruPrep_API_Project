using UserManagement_API.DTOs;
using UserManagement_API.Models;

namespace UserManagement_API.Repositories.Interfaces
{
    public interface IRegistrationService
    {
        Task<string> UserRegistration(RegistrationDtocs request);
    }
}
