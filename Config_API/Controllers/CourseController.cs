// BoardsController.cs
using Config_API.Repositories.Services;
using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateCourse(Course request)
    {
        try 
        {
            var data = await _courseService.AddUpdateCourse(request);
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
    [HttpGet("GetAllCourses")]
    public async Task<IActionResult> GetAllCoursesList()
    {
        try
        {
            var data = await _courseService.GetAllCourses();
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
    [HttpGet("GetCourse/{CourseId}")]
    public async Task<IActionResult> GetCourseById(int CourseId)
    {
        try
        {
            var data = await _courseService.GetCourseById(CourseId);
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
    [HttpPut("Status/{CourseId}")]
    public async Task<IActionResult> StatusActiveInactive(int CourseId)
    {
        try
        {
            var data = await _courseService.StatusActiveInactive(CourseId);
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
