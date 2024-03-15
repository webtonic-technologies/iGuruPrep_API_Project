using Config_API.Models;
using iGuruPrep;

public class StatusMessageRepository : IStatusMessageRepository
{
    private readonly DbContextClass _dbContext;

    public StatusMessageRepository(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> AddUpdateStatusMessage(StatusMessage request)
    {
        try
        {

            if (request.StatusId == 0)
            {
                var newStatusMessage = new StatusMessage
                {
                   StatusCode = request.StatusId,
                   StatusMessages = request.StatusMessages,
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
                    data.StatusMessages = request.StatusMessages;
                    data.StatusCode = request.StatusId;

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

    public async Task<StatusMessage> GetStatusMessageById(int id)
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
            return new StatusMessage();
        }
    }
    // Implement methods defined in the interface

}
