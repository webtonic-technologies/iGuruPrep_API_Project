using Config_API.Models;
using Config_API.Repositories.Interfaces;
using iGuruPrep;

namespace Config_API.Repositories.Services
{
    public class QuestionLevelService : IQuestionLevelService
    {
        private readonly DbContextClass _dbContext;
        public QuestionLevelService(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<string> AddUpdateQuestionLevel(QuestionLevel request)
        {
            try
            {

                if (request.LevelId == 0)
                {
                    var newQuestionLevel = new QuestionLevel
                    {
                       CreatedOn = DateTime.Now,
                       LevelCode = request.LevelCode,
                       LevelName = request.LevelName,
                       PatternCode = request.PatternCode,
                       Status = request.Status
                    };

                    _dbContext.tblDifficultyLevel.Add(newQuestionLevel);
                    _dbContext.SaveChanges();

                    return "Question Level created successfully.";
                }
                else
                {
                    var data = _dbContext.tblDifficultyLevel.Where(x => x.LevelId == request.LevelId).FirstOrDefault();
                    if (data != null)
                    {
                        data.LevelName = request.LevelName;
                        data.Status = request.Status;
                        data.PatternCode = request.PatternCode;
                        data.LevelCode = request.LevelCode;

                        _dbContext.tblDifficultyLevel.Update(data);
                        _dbContext.SaveChanges();

                        return "Question Level Updated successfully.";
                    }
                    else
                    {
                        return "Question Level does not exist.";
                    }
                }

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public async Task<List<QuestionLevel>> GetAllQuestionLevel()
        {
            try
            {
                var data = _dbContext.tblDifficultyLevel.Select(x => new QuestionLevel
                {
                    CreatedOn = x.CreatedOn,
                    LevelCode = x.LevelCode,
                    PatternCode = x.PatternCode,
                    LevelName = x.LevelName,
                    LevelId = x.LevelId,
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
                return new List<QuestionLevel>();
            }
        }

        public async Task<QuestionLevel> GetQuestionLevelById(int id)
        {
            try
            {
                var data = _dbContext.tblDifficultyLevel.Where(x => x.LevelId == id).FirstOrDefault();
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
                return new QuestionLevel();
            }
        }
        public async Task<bool> StatusActiveInactive(int id)
        {
            try
            {
                var data = _dbContext.tblDifficultyLevel.Where(x => x.LevelId == id).FirstOrDefault();
                if (data != null)
                {
                    if (data.Status == true)
                    {
                        data.Status = false;
                        _dbContext.tblDifficultyLevel.Update(data);
                        _dbContext.SaveChanges();
                        return true;
                    }
                    else
                    {
                        data.Status = true;
                        _dbContext.tblDifficultyLevel.Update(data);
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
