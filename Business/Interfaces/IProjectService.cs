using Business.Dtos;
using Business.Models;
using Data.Entities;

namespace Business.Interfaces
{
    public interface IProjectService
    {
        ProjectEntity CreateProject(ProjectRegistrationForm form);
        bool DeleteProjectById(int id);
        ProjectEntity GetProjectById(int id);
        IEnumerable<Project> GetAllProjects();
        ProjectEntity UpdateProject(ProjectEntity projectEntity);
    }
}