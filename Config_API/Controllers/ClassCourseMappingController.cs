// BoardsController.cs
using Config_API.Models;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class ClassCourseMappingController: ControllerBase
{
    private readonly IClassCourseService _classCourseService;

    public ClassCourseMappingController(IClassCourseService classCourseService)
    {
        _classCourseService = classCourseService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateClassCourseMapping(ClassCourseMapping request)
    {
        try 
        {
            var data = await _classCourseService.AddUpdateClassCourseMapping(request);
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
    [HttpGet("GetAllClassCourseMappings")]
    public async Task<IActionResult> GetAllClassCourseMappingsList()
    {
        try
        {
            var data = await _classCourseService.GetAllClassCoursesMappings();
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
    [HttpGet("GetClassCourseMapping/{CourseClassMappingID}")]
    public async Task<IActionResult> GetClassCourseMappingById(int CourseClassMappingID)
    {
        try
        {
            var data = await _classCourseService.GetClassCourseMappingById(CourseClassMappingID);
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
    [HttpPut("Status/{CourseClassMappingID}")]
    public async Task<IActionResult> StatusActiveInactive(int CourseClassMappingID)
    {
        try
        {
            var data = await _classCourseService.StatusActiveInactive(CourseClassMappingID);
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
