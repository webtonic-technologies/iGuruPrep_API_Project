using iGuruPrep;

public class BoardService : IBoardService
{
    private readonly DbContextClass _dbContext;

    public BoardService(DbContextClass dbContext)
    {
        _dbContext = dbContext;
    }
    // Implement methods defined in the interface
    public async Task<string> AddUpdateBoard(Board request)
    {
        try
        {

            if (request.BoardId == 0)
            {
                var newBoard = new Board
                {
                    BoardCode = request.BoardCode,
                    BoardName = request.BoardName,
                    ShowCourse = request.ShowCourse,
                    Status = request.Status,
                    CreatedOn = DateTime.Now,
                    CreatedBy = 1
                };

                _dbContext.tblBoard.Add(newBoard);
                _dbContext.SaveChanges();

                return "Board created successfully.";
            }
            else
            {
                var data = _dbContext.tblBoard.Where(x => x.BoardId == request.BoardId).FirstOrDefault();
                if (data != null)
                {
                    data.BoardName = request.BoardName;
                    data.BoardCode = request.BoardCode;
                    data.ShowCourse = request.ShowCourse;
                    data.Status = request.Status;
                    data.ModifiedOn = DateTime.Now;


                    _dbContext.tblBoard.Update(data);
                    _dbContext.SaveChanges();

                    return "Board Updated successfully.";
                }
                else
                {
                    return "Board does not exist.";
                }
            }

        }
        catch (Exception ex)
        {
            return ex.Message;
        }

    }


    public async Task<List<Board>> GetAllBoards()
    {
        try
        {
            var data = _dbContext.tblBoard.Select(x => new Board
            {
                BoardId = x.BoardId,
                BoardCode = x.BoardCode,
                BoardName = x.BoardName,
                CreatedBy = x.CreatedBy,
                CreatedOn = x.CreatedOn,
                ModifiedBy = x.ModifiedBy,
                ModifiedOn = x.ModifiedOn,
                ShowCourse = x.ShowCourse,
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
            return new List<Board>();
        }
    }

    public async Task<Board> GetBoardById(int id)
    {
        try
        {
            var data = _dbContext.tblBoard.Where(x => x.BoardId == id).FirstOrDefault();
            if(data != null)
            {
                return data;
            }
            else
            {
                return null;
            }
        } 
        catch (Exception ex) {
            return new Board();
        }
    }

    public async Task<bool> StatusActiveInactive(int id)
    {
        try
        {
            var data = _dbContext.tblBoard.Where(x => x.BoardId == id).FirstOrDefault();
            if (data != null)
            {
                if (data.Status == true)
                {
                    data.Status = false;
                    _dbContext.tblBoard.Update(data);
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    data.Status = true;
                    _dbContext.tblBoard.Update(data);
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
