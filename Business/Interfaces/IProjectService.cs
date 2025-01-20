using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        ProjectEntity CreateProject(ProjectEntity projectEntity);
        bool DeleteProjectById(int id);
        ProjectEntity GetProjectById(int id);
        IEnumerable<ProjectEntity> GetProjects();
        ProjectEntity UpdateProject(ProjectEntity projectEntity);
    }
}