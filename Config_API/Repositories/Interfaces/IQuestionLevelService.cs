using Config_API.Models;

namespace Config_API.Repositories.Interfaces
{
    public interface IQuestionLevelService
    {
       Task<List<QuestionLevel>> GetAllQuestionLevel();
        Task<QuestionLevel> GetQuestionLevelById(int id);
        Task<string> AddUpdateQuestionLevel(QuestionLevel request);
        Task<bool> StatusActiveInactive(int id);
    }
}
