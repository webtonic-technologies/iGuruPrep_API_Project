using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;

namespace iGuruPrep.Repositories.Services
{
    public class CourseService : ICourseService
    {
        private readonly DbContextClass _dbContext;
        public CourseService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<string> AddUpdateCourse(Course request)
        {
            try
            {

                if (request.CourseId == 0)
                {
                    var newCourse = new Course
                    {
                      CourseCode = request.CourseCode,
                      CourseName = request.CourseName,
                      CreatedBy = request.CreatedBy,
                      CreatedOn = DateTime.Now,
                      DisplayOrder = request.DisplayOrder,
                      ModifiedBy = request.ModifiedBy,
                      ModifiedOn = DateTime.Now,
                      Status = request.Status
                    };

                    _dbContext.tblCourse.Add(newCourse);
                    _dbContext.SaveChanges();

                    return "Course created successfully.";
                }
                else
                {
                    var data = _dbContext.tblCourse.Where(x => x.CourseId == request.CourseId).FirstOrDefault();
                    if (data != null)
                    {

                        data.CourseCode = request.CourseCode;
                        data.CourseName = request.CourseName;
                        data.CreatedBy = request.CreatedBy;
                        data.CreatedOn = request.CreatedOn;
                        data.DisplayOrder = request.DisplayOrder;
                        data.ModifiedBy = request.ModifiedBy;
                        data.ModifiedOn = DateTime.Now;
                        data.Status = request.Status;


                        _dbContext.tblCourse.Update(data);
                        _dbContext.SaveChanges();

                        return "Course Updated successfully.";
                    }
                    else
                    {
                        return "Course does not exist.";
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Course>> GetAllCourses()
        {
            try
            {
                var data = _dbContext.tblCourse.Select(x => new Course
                {
                    CourseId = x.CourseId,
                    CourseCode = x.CourseCode,
                    CourseName = x.CourseName,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    DisplayOrder = x.DisplayOrder,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedOn = x.ModifiedOn,
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
                return new List<Course>();
            }
        }

        public async Task<Course> GetCourseById(int id)
        {
            try
            {
                var data = _dbContext.tblCourse.Where(x => x.CourseId == id).FirstOrDefault();
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
                return new Course();
            }
        }
        public async Task<bool> StatusActiveInactive(int id)
        {
            try
            {
                var data = _dbContext.tblCourse.Where(x => x.CourseId == id).FirstOrDefault();
                if (data != null)
                {
                    if (data.Status == true)
                    {
                        data.Status = false;
                        _dbContext.tblCourse.Update(data);
                        _dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        data.Status = true;
                        _dbContext.tblCourse.Update(data);
                        _dbContext.SaveChanges();
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
