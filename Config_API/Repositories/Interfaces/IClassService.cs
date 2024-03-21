using iGuruPrep.Models;

namespace iGuruPrep.Repositories.Interfaces
{
    public interface IClassService
    {
        Task<List<Class>> GetAllClasses();
        Task<Class> GetClassById(int id);
        Task<string> AddUpdateClass(Class request);
        Task<bool> StatusActiveInactive(int id);
    }
}
