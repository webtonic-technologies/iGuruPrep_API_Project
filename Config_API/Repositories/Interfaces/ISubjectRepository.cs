using iGuruPrep.Models;

namespace iGuruPrep.Repositories.Interfaces
{
    public interface ISubjectRepository
    {
        Task<List<Subject>> GetAllSubjects();
        Task<Subject> GetSubjectById(int id);
        Task<string> AddUpdateSubject(Subject request);
    }
}
