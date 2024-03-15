// BoardsController.cs
using iGuruPrep.Models;
using iGuruPrep.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class SubjectsController : ControllerBase
{
    private readonly ISubjectRepository _subjectRepository;

    public SubjectsController(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateSubject(Subject request)
    {
        try 
        {
            var data = await _subjectRepository.AddUpdateSubject(request);
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
    [HttpGet("GetAllSubjects")]
    public async Task<IActionResult> GetAllSubjectsList()
    {
        try
        {
            var data = await _subjectRepository.GetAllSubjects();
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
    [HttpGet("GetSubject/{SubjectId}")]
    public async Task<IActionResult> GetSubjectById(int SubjectId)
    {
        try
        {
            var data = await _subjectRepository.GetSubjectById(SubjectId);
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
