using Config_API.Models;

public interface IStatusMessageService
{
    Task<StatusMessage> GetStatusMessageById(int id);
    Task<string> AddUpdateStatusMessage(StatusMessage request);
}
