using Schools_API.DTOs;

namespace Schools_API.Repositories.Interfaces
{
    public interface IProjectRepository
    {
        Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO);
        Task<IEnumerable<ProjectDTO>> GetAllProjectsByFilter(ProjectFilter filter);
        Task<ProjectDetailsDTO> GetProjectByIdAsync(int projectId);
    }
}
