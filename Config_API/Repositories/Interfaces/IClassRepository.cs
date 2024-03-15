using iGuruPrep.Models;

namespace iGuruPrep.Repositories.Interfaces
{
    public interface IClassRepository
    {
        Task<List<Class>> GetAllClasses();
        Task<Class> GetClassById(int id);
        Task<string> AddUpdateClass(Class request);
    }
}
