using Microsoft.AspNetCore.Mvc;
using Schools_API.DTOs;
using Schools_API.Repositories.Interfaces;

namespace Schools_API.Controllers
{
    [Route("iGuru/[controller]")]
    [ApiController]

    public class ProjectController : ControllerBase
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectController(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        [HttpPost("AddProject")]
        public async Task<IActionResult> AddProject([FromForm] ProjectDTO projectDTO)
        {
            try
            {

                if (projectDTO == null)
                {
                    return BadRequest("Project data is null.");
                }

                var createdProject = await _projectRepository.AddProjectAsync(projectDTO);

                if (createdProject.ProjectId <= 0)
                {
                    return StatusCode(500, "A problem happened while handling your request.");
                }

                return Ok(createdProject);
            }
            catch (Exception e)
            {
                return this.BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects([FromQuery] ProjectFilter filter)
        {
            var projects = await _projectRepository.GetAllProjectsByFilter(filter);

            if (projects == null || !projects.Any())
            {
                return NotFound("No projects found.");
            }

            return Ok(projects);
        }
        [HttpGet("GetProjectById/{projectId}")]
        public async Task<IActionResult> GetProjectById(int projectId)
        {
            var project = await _projectRepository.GetProjectByIdAsync(projectId);

            if (project == null)
            {
                return NotFound("Project not found.");
            }

            return Ok(project);
        }
    }
}
