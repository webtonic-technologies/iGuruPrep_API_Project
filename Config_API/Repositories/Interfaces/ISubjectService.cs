using iGuruPrep.Models;

namespace iGuruPrep.Repositories.Interfaces
{
    public interface ISubjectService
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<string> AddUpdateSubject(Subject request);
        Task<bool> StatusActiveInactive(int id);
    }
}
