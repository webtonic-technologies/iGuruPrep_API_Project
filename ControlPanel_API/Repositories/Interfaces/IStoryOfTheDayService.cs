using ControlPanel_API.DTOs;

namespace ControlPanel_API.Repositories.Interfaces
{
    public interface IStoryOfTheDayService
    {
        Task AddNewStoryOfTheDay(StoryOfTheDayDTO storyOfTheDayDTO);
        Task UpdateStoryOfTheDay(UpdateStoryOfTheDayDTO storyOfTheDayDTO);
        Task<IEnumerable<StoryOfTheDayDTO>> GetAllStoryOfTheDay();
        Task<StoryOfTheDayDTO> GetStoryOfTheDayById(int id);
        Task DeleteStoryOfTheDay(int id);
        Task UpdateStoryOfTheDayFile(StoryOfTheDayIdAndFileDTO storyOfTheDayDTO);
        Task<byte[]> GetStoryOfTheDayFileById(int id);
    }
}