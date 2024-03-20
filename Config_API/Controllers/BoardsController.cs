// BoardsController.cs
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class BoardsController : ControllerBase
{
    private readonly IBoardService _boardService;

    public BoardsController(IBoardService boardService)
    {
        _boardService = boardService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateBoard(Board board)
    {
        try 
        {
            var data = await _boardService.AddUpdateBoard(board);
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
            var data = await _boardService.GetAllBoards();
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
            var data = await _boardService.GetBoardById(BoardId);
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
    [HttpPut("Status/{BoardId}")]
    public async Task<IActionResult> StatusActiveInactive(int BoardId)
    {
        try
        {
            var data = await _boardService.StatusActiveInactive(BoardId);
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
