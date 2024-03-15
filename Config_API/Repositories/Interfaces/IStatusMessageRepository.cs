using Config_API.Models;

public interface IStatusMessageRepository
{
    Task<StatusMessage> GetStatusMessageById(int id);
    Task<string> AddUpdateStatusMessage(StatusMessage request);
}
