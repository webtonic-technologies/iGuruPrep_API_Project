using ControlPanel_API.DTOs;
using ControlPanel_API.Models;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IFeedBackService
    {
        Task<string> AddFeedBack(Feedback request);
        Task<List<GetAllFeedbackResponse>> GetAllFeedBackList(GetAllFeedbackRequest request);
    }
}
