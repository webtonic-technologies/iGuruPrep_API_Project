using Config_API.Models;
using iGuruPrep;

public class StatusMessageService : IStatusMessageService
{
    private readonly DbContextClass _dbContext;

    public StatusMessageService(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddUpdateStatusMessage(StatusMessages request)
    {
        try
        {

            if (request.StatusId == 0)
            {
                var newStatusMessage = new StatusMessages
                {
                   StatusCode = request.StatusCode,
                   StatusMessage = request.StatusMessage,
                };

                _dbContext.tblStatusMessage.Add(newStatusMessage);
                _dbContext.SaveChanges();

                return "Success Message Added successfully.";
            }
            else
            {
                var data = _dbContext.tblStatusMessage.Where(x => x.StatusId == request.StatusId).FirstOrDefault();
                if (data != null)
                {
                    data.StatusMessage = request.StatusMessage;
                    data.StatusCode = request.StatusCode;

                    _dbContext.tblStatusMessage.Update(data);
                    _dbContext.SaveChanges();

                    return "Success Message Updated successfully.";
                }
                else
                {
                    return "Success Message does not exist.";
                }
            }

        }
        catch (Exception ex)
        {
            return ex.Message;
        }
    }

    public async Task<StatusMessages> GetStatusMessageById(int id)
    {
        try
        {
            var data = _dbContext.tblStatusMessage.Where(x => x.StatusId == id).FirstOrDefault();
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
            return new StatusMessages();
        }
    }
    // Implement methods defined in the interface

}
