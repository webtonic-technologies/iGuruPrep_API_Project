
using Config_API.Models;
using iGuruPrep;
using iGuruPrep.Models;

namespace Config_API.Repositories.Services
{
    public class ClassCourseRepository : IClassCourseRepository
    {
        private readonly DbContextClass _dbContext;

        public ClassCourseRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddUpdateClassCourseMapping(ClassCourseMapping request)
        {
            try
            {

                if (request.CourseClassMappingID == 0)
                {
                    var classData = _dbContext.tblClass.Where(x => x.ClassId == request.ClassID).FirstOrDefault();
                    var courseData = _dbContext.tblCourse.Where(x=>x.CourseId == request.CourseID).FirstOrDefault();

                    if(classData != null && courseData != null)
                    {

                        var newClassCourseMapping = new ClassCourseMapping
                        {
                            ClassID = request.CourseClassMappingID,
                            CourseID = request.CourseClassMappingID,
                            CreatedOn = DateTime.Now,
                            Status = request.Status
                        };

                        _dbContext.tblClassCourses.Add(newClassCourseMapping);
                        _dbContext.SaveChanges();

                        return "Class and Course Mapped successfully.";
                    }
                    else
                    {
                        return "Please enter valid data";
                    }

                }
                else
                {
                    var data = _dbContext.tblClassCourses.Where(x => x.CourseClassMappingID == request.CourseClassMappingID).FirstOrDefault();
                    if (data != null)
                    {
                        data.CreatedOn = request.CreatedOn;
                        data.Status = request.Status;
                        data.ClassID = request.ClassID;
                        data.CourseID = request.CourseClassMappingID;


                        _dbContext.tblClassCourses.Update(data);
                        _dbContext.SaveChanges();

                        return "Class Course Mapping Updated successfully.";
                    }
                    else
                    {
                        return "Mapping does not exist.";
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<ClassCourseMapping>> GetAllClassCoursesMappings()
        {
            try
            {
                var data = _dbContext.tblClassCourses.Select(x => new ClassCourseMapping
                {
                    CreatedOn = x.CreatedOn,
                    CourseID = x.CourseID,
                    ClassID = x.ClassID,
                    CourseClassMappingID = x.CourseClassMappingID,
                    Status = x.Status
                }).ToList();

                if (data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new List<ClassCourseMapping>();
            }
        }

        public async Task<ClassCourseMapping> GetClassCourseMappingById(int id)
        {
            try
            {
                var data = _dbContext.tblClassCourses.Where(x => x.CourseClassMappingID == id).FirstOrDefault();
                if (data != null)
                {
                    return data;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return new ClassCourseMapping();
            }
        }
    }
}
