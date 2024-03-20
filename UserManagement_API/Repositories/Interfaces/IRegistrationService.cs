using UserManagement_API.DTOs;

namespace UserManagement_API.Repositories.Interfaces
{
    public interface IRegistrationService
    {
        Task<string> UserRegistration(RegistrationDtocs request);
    }
}
