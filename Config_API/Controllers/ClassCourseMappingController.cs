// BoardsController.cs
using Config_API.Models;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class ClassCourseMappingController: ControllerBase
{
    private readonly IClassCourseRepository _classCourseRepository;

    public ClassCourseMappingController(IClassCourseRepository classCourseRepository)
    {
        _classCourseRepository = classCourseRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateClassCourseMapping(ClassCourseMapping request)
    {
        try 
        {
            var data = await _classCourseRepository.AddUpdateClassCourseMapping(request);
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
            var data = await _classCourseRepository.GetAllClassCoursesMappings();
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
            var data = await _classCourseRepository.GetClassCourseMappingById(CourseClassMappingID);
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
