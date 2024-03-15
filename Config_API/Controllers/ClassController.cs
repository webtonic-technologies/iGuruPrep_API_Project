// BoardsController.cs
using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class ClassController : ControllerBase
{
    private readonly IClassRepository _classRepository;

    public ClassController(IClassRepository classRepository)
    {
        _classRepository = classRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateClass(Class request)
    {
        try 
        {
            var data = await _classRepository.AddUpdateClass(request);
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
    [HttpGet("GetAllClasses")]
    public async Task<IActionResult> GetAllClassesList()
    {
        try
        {
            var data = await _classRepository.GetAllClasses();
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
    [HttpGet("GetClass/{ClassId}")]
    public async Task<IActionResult> GetClassById(int ClassId)
    {
        try
        {
            var data = await _classRepository.GetClassById(ClassId);
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
