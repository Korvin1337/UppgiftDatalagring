using Business.Dtos;
using Business.Models;
using Data.Entities;
using System.Linq.Expressions;

namespace Business.Interfaces;

public interface IProjectService
{
    Task<IResult> CreateProjectAsync(ProjectRegistrationForm form);
    Task<IResult> GetAllProjectsAsync();
    /*Task<IResult> AlreadyExistsAsync();*/
    Task<IResult> GetProjectAsync(int id);
    Task<IResult> UpdateProjectAsync(int id, ProjectUpdateForm form);
    Task<IResult> DeleteProjectAsync(int id);
}