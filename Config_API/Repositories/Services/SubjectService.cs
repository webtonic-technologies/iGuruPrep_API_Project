using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;

namespace iGuruPrep.Repositories.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly DbContextClass _dbContext;
        public SubjectService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AddUpdateSubject(Subject request)
        {

            try
            {

                if (request.SubjectId == 0)
                {
                    var newSubject = new Subject
                    {
                      ColorCode = request.ColorCode,
                      SubjectName = request.SubjectName,
                      SubjectCode = request.SubjectCode,
                      CreatedBy = request.CreatedBy,
                      CreatedOn = DateTime.Now,
                      DisplayOrder = request.DisplayOrder,
                      GroupName = request.GroupName,
                      Icon = request.Icon,
                      ModifiedBy = request.ModifiedBy,  
                      ModifiedOn = DateTime.Now,
                      Status = request.Status,
                      SubjectType = request.SubjectType
                    };

                    _dbContext.tblSubject.Add(newSubject);
                    _dbContext.SaveChanges();

                    return "Subject created successfully.";
                }
                else
                {
                    var data = _dbContext.tblSubject.Where(x => x.SubjectId == request.SubjectId).FirstOrDefault();
                    if (data != null)
                    {
                        data.ColorCode = request.ColorCode;
                        data.SubjectName = request.SubjectName;
                        data.SubjectCode = request.SubjectCode;
                        data.CreatedBy = request.CreatedBy;
                        data.CreatedOn = request.CreatedOn;
                        data.DisplayOrder = request.DisplayOrder;
                        data.GroupName = request.GroupName;
                        data.Icon = request.Icon;
                        data.ModifiedBy = request.ModifiedBy;
                        data.ModifiedOn = DateTime.Now;
                        data.Status = request.Status;
                        data.SubjectType = request.SubjectType;


                        _dbContext.tblSubject.Update(data);
                        _dbContext.SaveChanges();

                        return "Subject Updated successfully.";
                    }
                    else
                    {
                        return "Subject does not exist.";
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<Subject>> GetAllSubjects()
        {
            try
            {
                var data = _dbContext.tblSubject.Select(x => new Subject
                {
                    SubjectId = x.SubjectId,
                    ColorCode = x.ColorCode,
                    SubjectName = x.SubjectName,
                    SubjectCode = x.SubjectCode,
                    CreatedBy = x.CreatedBy,
                    CreatedOn = x.CreatedOn,
                    DisplayOrder = x.DisplayOrder,
                    GroupName = x.GroupName,
                    Icon = x.Icon,
                    ModifiedBy = x.ModifiedBy,
                    ModifiedOn = x.ModifiedOn,
                    Status = x.Status,
                    SubjectType = x.SubjectType
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
                return new List<Subject>();
            }
        }

        public async Task<Subject> GetSubjectById(int id)
        {
            try
            {
                var data = _dbContext.tblSubject.Where(x => x.SubjectId == id).FirstOrDefault();
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
                return new Subject();
            }
        }
        public async Task<bool> StatusActiveInactive(int id)
        {
            try
            {
                var data = _dbContext.tblSubject.Where(x => x.SubjectId == id).FirstOrDefault();
                if (data != null)
                {
                    if (data.Status == true)
                    {
                        data.Status = false;
                        _dbContext.tblSubject.Update(data);
                        _dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        data.Status = true;
                        _dbContext.tblSubject.Update(data);
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
