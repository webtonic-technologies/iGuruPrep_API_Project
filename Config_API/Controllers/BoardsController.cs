// BoardsController.cs
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly IBoardRepository _boardRepository;

    public BoardsController(IBoardRepository boardRepository)
    {
        _boardRepository = boardRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateBoard(Board board)
    {
        try 
        {
            var data = await _boardRepository.AddUpdateBoard(board);
            if(data != null)
            {
                return Ok(data);

            }
            else
            {
                return BadRequest("Bad Request");
            }

        }
        catch (Exception e)
        {
            return this.BadRequest(e.Message);
        }

    }
    [HttpGet("GetAllBoards")]
    public async Task<IActionResult> GetAllBoardsList()
    {
        try
        {
            var data = await _boardRepository.GetAllBoards();
            if (data != null)
            {
                return Ok(data);

            }
            else
            {
                return BadRequest("Bad Request");
            }

        }
        catch (Exception e)
        {
            return this.BadRequest(e.Message);
        }

    }
    [HttpGet("GetBoard/{BoardId}")]
    public async Task<IActionResult> GetBoardById(int BoardId)
    {
        try
        {
            var data = await _boardRepository.GetBoardById(BoardId);
            if (data != null)
            {
                return Ok(data);

            }
            else
            {
                return BadRequest("Bad Request");
            }

        }
        catch (Exception e)
        {
            return this.BadRequest(e.Message);
        }

    }
}
