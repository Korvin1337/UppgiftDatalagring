using Business.Dtos;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        ProjectEntity CreateProject(ProjectRegistrationForm form);
        bool DeleteProjectById(int id);
        ProjectEntity GetProjectById(int id);
        IEnumerable<ProjectEntity> GetAllProjects();
        ProjectEntity UpdateProject(ProjectEntity projectEntity);
    }
}