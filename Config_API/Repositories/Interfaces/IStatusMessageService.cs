using Config_API.Models;

public interface IStatusMessageService
{
    Task<StatusMessages> GetStatusMessageById(int id);
    Task<string> AddUpdateStatusMessage(StatusMessages request);
}
