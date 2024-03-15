// BoardsController.cs
using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ICourseRepository _courseRepository;

    public CourseController(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateCourse(Course request)
    {
        try 
        {
            var data = await _courseRepository.AddUpdateCourse(request);
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
            var data = await _courseRepository.GetAllCourses();
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
            var data = await _courseRepository.GetCourseById(CourseId);
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
