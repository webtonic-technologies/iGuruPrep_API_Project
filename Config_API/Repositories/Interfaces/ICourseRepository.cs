using iGuruPrep.Models;

namespace iGuruPrep.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAllCourses();
        Task<Course> GetCourseById(int id);
        Task<string> AddUpdateCourse(Course request);
    }
}
