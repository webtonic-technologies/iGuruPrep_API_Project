﻿// BoardsController.cs
using Config_API.Models;
using Config_API.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("iGuru/[controller]")]
[ApiController]
public class QuestionLevelController : ControllerBase
{
    private readonly IQuestionLevelService _questionLevelService;

    public QuestionLevelController(IQuestionLevelService questionLevelService)
    {
        _questionLevelService = questionLevelService;
    }

    [HttpPost]
    public async Task<IActionResult> AddUpdateQuestionLevel(QuestionLevel request)
    {
        try 
        {
            var data = await _questionLevelService.AddUpdateQuestionLevel(request);
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
    [HttpGet("GetAllQuestionLevels")]
    public async Task<IActionResult> GetAllQuestionLevelsList()
    {
        try
        {
            var data = await _questionLevelService.GetAllQuestionLevel();
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
    [HttpGet("GetQuestionLevel/{QuestionLevelId}")]
    public async Task<IActionResult> GetQuestionLevelById(int QuestionLevelId)
    {
        try
        {
            var data = await _questionLevelService.GetQuestionLevelById(QuestionLevelId);
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
    [HttpPut("Status/{QuestionLevelId}")]
    public async Task<IActionResult> StatusActiveInactive(int QuestionLevelId)
    {
        try
        {
            var data = await _questionLevelService.StatusActiveInactive(QuestionLevelId);
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
