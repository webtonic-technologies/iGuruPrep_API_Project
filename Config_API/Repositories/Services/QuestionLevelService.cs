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

                if (request.QuestionLevelId == 0)
                {
                    var newQuestionLevel = new QuestionLevel
                    {
                        NoOfQuestions = request.NoOfQuestions,
                        QuestionLevelCode = request.QuestionLevelCode,
                        QuestionLevelName = request.QuestionLevelName,
                        Status = request.Status,
                        SuccessRate = request.SuccessRate
                    };

                    _dbContext.tblDifficultyLevel.Add(newQuestionLevel);
                    _dbContext.SaveChanges();

                    return "Question Level created successfully.";
                }
                else
                {
                    var data = _dbContext.tblDifficultyLevel.Where(x => x.QuestionLevelId == request.QuestionLevelId).FirstOrDefault();
                    if (data != null)
                    {
                        data.QuestionLevelName = request.QuestionLevelName;
                        data.Status = request.Status;
                        data.SuccessRate = request.SuccessRate;
                        data.QuestionLevelCode = request.QuestionLevelCode;
                        data.NoOfQuestions = request.NoOfQuestions;

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
                    NoOfQuestions = x.NoOfQuestions,
                    QuestionLevelCode = x.QuestionLevelCode,
                    QuestionLevelName = x.QuestionLevelName,
                    QuestionLevelId = x.QuestionLevelId,
                    SuccessRate = x.SuccessRate,
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
                var data = _dbContext.tblDifficultyLevel.Where(x => x.QuestionLevelId == id).FirstOrDefault();
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
                var data = _dbContext.tblDifficultyLevel.Where(x => x.QuestionLevelId == id).FirstOrDefault();
                if (data != null)
                {
                    data.Status = false;
                    _dbContext.tblDifficultyLevel.Update(data);
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
