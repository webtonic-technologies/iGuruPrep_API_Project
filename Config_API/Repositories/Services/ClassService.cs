using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;

namespace iGuruPrep.Repositories.Services
{
    public class ClassService : IClassService
    {
        private readonly DbContextClass _dbContext;
        public ClassService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AddUpdateClass(Class request)
        {
            try
            {

                if (request.ClassId == 0)
                {
                    var newClass = new Class
                    {
                       ClassCode = request.ClassCode,
                       ClassName = request.ClassName,
                       CreatedBy = request.CreatedBy,
                       CreatedOn = DateTime.Now,
                       DisplayOrder = request.DisplayOrder,
                       ModifiedBy = request.ModifiedBy,
                       ModifiedOn = request.ModifiedOn,
                       ShowCourse = request.ShowCourse,
                       Status = request.Status,
                    };

                    _dbContext.tblClass.Add(newClass);
                    _dbContext.SaveChanges();

                    return "Class created successfully.";
                }
                else
                {
                    var data = _dbContext.tblClass.Where(x => x.ClassId == request.ClassId).FirstOrDefault();
                    if (data != null)
                    {
                        data.ClassCode = request.ClassCode;
                        data.ClassName = request.ClassName;
                        data.CreatedBy = request.CreatedBy;
                        data.CreatedOn = request.CreatedOn;
                        data.DisplayOrder = request.DisplayOrder;
                        data.ModifiedBy = request.ModifiedBy;
                        data.ModifiedOn = DateTime.Now;
                        data.ShowCourse = request.ShowCourse;
                        data.Status = request.Status;


                        _dbContext.tblClass.Update(data);
                        _dbContext.SaveChanges();

                        return "Class Updated successfully.";
                    }
                    else
                    {
                        return "Class does not exist.";
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Class>> GetAllClasses()
        {
            try
            {
                var data = _dbContext.tblClass.Select(x => new Class
                {
                    ClassId = x.ClassId,
                    Status = x.Status,
                    ShowCourse = x.ShowCourse,
                    ModifiedOn = x.ModifiedOn,
                    ClassCode = x.ClassCode,
                    ClassName = x.ClassName,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    DisplayOrder = x.DisplayOrder,
                    ModifiedBy = x.ModifiedBy,
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
                return new List<Class>();
            }
        }

        public async Task<Class> GetClassById(int id)
        {
            try
            {
                var data = _dbContext.tblClass.Where(x => x.ClassId == id).FirstOrDefault();
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
                return new Class();
            }
        }
        public async Task<bool> StatusActiveInactive(int id)
        {
            try
            {
                var data = _dbContext.tblClass.Where(x => x.ClassId == id).FirstOrDefault();
                if (data != null)
                {
                    data.Status = false;
                    _dbContext.tblClass.Update(data);
                    _dbContext.SaveChanges();
                    return true;
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
