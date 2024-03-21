using iGuruPrep.Models;

namespace iGuruPrep.Repositories.Interfaces
{
    public interface ICourseService
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<string> AddUpdateCourse(Course request);
        Task<bool> StatusActiveInactive(int id);
    }
}
