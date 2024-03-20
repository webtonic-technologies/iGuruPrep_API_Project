public interface IBoardService
{
    Task<List<Board>> GetAllBoards();
    Task<Board> GetBoardById(int id);
    Task<string> AddUpdateBoard(Board board);
    Task<bool> StatusActiveInactive(int id);
}
