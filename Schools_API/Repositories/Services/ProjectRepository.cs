using Microsoft.EntityFrameworkCore;
using Schools_API.DTOs;
using Schools_API.Models;
using Schools_API.Repositories.Interfaces;

namespace Schools_API.Repositories.Services
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly DbContextClass _dbContext;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ProjectRepository(DbContextClass dbContext, IWebHostEnvironment hostingEnvironment)
        {
            _dbContext = dbContext;
            _hostingEnvironment = hostingEnvironment;
        }


        public async Task<IEnumerable<ProjectDTO>> GetAllProjectsByFilter(ProjectFilter filter)
        {
            try
            {
                //var filteredProjects = await _dbContext.tblproject
                //    .Where(p => (filter.BoardId.HasValue && p.BoardId == filter.BoardId.Value) ||
                //                (filter.ClassId.HasValue && p.ClassId == filter.ClassId.Value) ||
                //                (filter.CourseId.HasValue && p.CourseId == filter.CourseId.Value) ||
                //                (filter.SubjectId.HasValue && p.SubjectId == filter.SubjectId.Value))
                //    .Select(p => new ProjectDTO
                //    {
                //        ProjectId = p.ProjectId,
                //        ProjectName = p.ProjectName,
                //        ProjectDescription = p.ProjectDescription,
                //        PathURL = p.PathURL,
                //        CourseId = p.CourseId,
                //        ClassId = p.ClassId,
                //        BoardId = p.BoardId,
                //        SubjectId = p.SubjectId,
                //        CreatedBy = p.CreatedBy
                //    })
                //    .ToListAsync();

                var query = _dbContext.tblproject.AsQueryable();

                // Apply filters conditionally
                if (filter.BoardId.HasValue)
                    query = query.Where(p => p.BoardId == filter.BoardId.Value);
                if (filter.ClassId.HasValue)
                    query = query.Where(p => p.ClassId == filter.ClassId.Value);
                if (filter.CourseId.HasValue)
                    query = query.Where(p => p.CourseId == filter.CourseId.Value);
                if (filter.SubjectId.HasValue)
                    query = query.Where(p => p.SubjectId == filter.SubjectId.Value);

                var filteredProjects = await query
                    .Select(p => new ProjectDTO
                    {
                        ProjectId = p.ProjectId,
                        ProjectName = p.ProjectName,
                        ProjectDescription = p.ProjectDescription,
                        PathURL = p.PathURL != null ? Path.Combine(_hostingEnvironment.ContentRootPath, "ProjectImages", p.PathURL) : null,
                        //PathURL = p.PathURL,
                        CourseId = p.CourseId,
                        ClassId = p.ClassId,
                        BoardId = p.BoardId,
                        SubjectId = p.SubjectId,
                        CreatedBy = p.CreatedBy
                    })
                    .ToListAsync();

                return filteredProjects;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ProjectDTO> AddProjectAsync(ProjectDTO projectDTO)
        {
            try
            {
                string imagePath = null;
                if (projectDTO.image != null)
                {
                    var folderName = Path.Combine(_hostingEnvironment.ContentRootPath, "ProjectImages");
                    if (!Directory.Exists(folderName))
                    {
                        Directory.CreateDirectory(folderName);
                    }
                    var fileName = Path.GetFileNameWithoutExtension(projectDTO.image.FileName) + "_" + Guid.NewGuid().ToString() + Path.GetExtension(projectDTO.image.FileName);
                    var filePath = Path.Combine(folderName, fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        projectDTO.image.CopyTo(fileStream);
                    }
                    imagePath = fileName; // Set the path where the image is saved
                }
                else
                {
                    imagePath = string.Empty;
                }

                var project = new Project
                {
                    ProjectName = projectDTO.ProjectName,
                    ProjectDescription = projectDTO.ProjectDescription,
                    PathURL = imagePath,
                    BoardId = projectDTO.BoardId,
                    ClassId = projectDTO.ClassId,
                    CourseId = projectDTO.CourseId,
                    SubjectId = projectDTO.SubjectId,
                    CreatedBy = projectDTO.CreatedBy // Assuming CreatedBy is provided in DTO
                };

                await _dbContext.tblproject.AddAsync(project);
                await _dbContext.SaveChangesAsync();

                projectDTO.ProjectId = project.ProjectId; // Set the ID of the newly created project
                return projectDTO;
            }
            catch (Exception ex) { return null; }
        }
        public async Task<ProjectDetailsDTO> GetProjectByIdAsync(int projectId)
        {
            try
            {
                var project = await _dbContext.tblproject
                .Where(p => p.ProjectId == projectId)
                .Select(p => new ProjectDetailsDTO
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    ProjectDescription = p.ProjectDescription,
                    ImageName = p.PathURL,
                    PathURL = p.PathURL != null ? Path.Combine(_hostingEnvironment.ContentRootPath, "ProjectImages", p.PathURL) : null,
                    //PathURL = Path.Combine(_hostingEnvironment.WebRootPath, "ProjectImages", p.PathURL),
                    CourseName = _dbContext.tblCourse.Where(c => c.CourseId == p.CourseId).Select(c => c.CourseName).FirstOrDefault(),
                    ClassName = _dbContext.tblClass.Where(cl => cl.ClassId == p.ClassId).Select(cl => cl.ClassName).FirstOrDefault(),
                    BoardName = _dbContext.tblBoard.Where(b => b.BoardId == p.BoardId).Select(b => b.BoardName).FirstOrDefault(),
                    SubjectName = _dbContext.tblSubject.Where(s => s.SubjectId == p.SubjectId).Select(s => s.SubjectName).FirstOrDefault(),
                    CreatedBy = p.CreatedBy
                })
                .FirstOrDefaultAsync();

                //project.PathURL = Path.Combine(_hostingEnvironment.ContentRootPath, "ProjectImages", project.ImageName);

                if (project == null)
                {
                    throw new KeyNotFoundException("Project not found.");
                }

                return project;
            }
            catch (Exception ex) { return null; }
        }


    }
}
