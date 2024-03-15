using Config_API.Models;

public interface IClassCourseRepository
{
    Task<List<ClassCourseMapping>> GetAllClassCoursesMappings();
    Task<ClassCourseMapping> GetClassCourseMappingById(int id);
    Task<string> AddUpdateClassCourseMapping(ClassCourseMapping request);
}
