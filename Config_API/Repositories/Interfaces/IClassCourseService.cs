using Config_API.Models;

public interface IClassCourseService
{
    Task<List<ClassCourseMapping>> GetAllClassCoursesMappings();
    Task<ClassCourseMapping> GetClassCourseMappingById(int id);
    Task<string> AddUpdateClassCourseMapping(ClassCourseMapping request);
    Task<bool> StatusActiveInactive(int id);
}
