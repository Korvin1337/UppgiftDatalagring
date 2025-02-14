using Business.Dtos;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using Data.Contexts;
using Data.Entities;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class ProjectService(IProjectRepository projectRepository) : IProjectService
{
    private readonly IProjectRepository _projectRepository = projectRepository;

    /*public async Task<IResult> AlreadyExistsAsync()
    {
        throw new NotImplementedException();
    }*/

    public async Task<IResult> CreateProjectAsync(ProjectRegistrationForm form)
    {
        if (form == null)
            return Result.BadRequest("Invalid registration form");

        try
        {
            if (await _projectRepository.ExistsAsync(x => x.ProjectName == form.ProjectName))
                return Result.AlreadyExists("project with same name already excists");

            var projectEntity = ProjectFactory.Create(form);

            var result = await _projectRepository.CreateAsync(projectEntity);
            return result ? Result.Ok() : Result.Error("Unable to create project.");
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetAllProjectsAsync()
    {
        try
        {
            var projectEntities = await _projectRepository.GetAllSync();
            var projects = projectEntities?.Select(ProjectFactory.Create);

            return Result<IEnumerable<Project>>.Ok(projects);
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> GetProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == id);
            if (projectEntity == null)
                return Result.NotFound("Project was not found.");

            var project = ProjectFactory.Create(projectEntity);
            return Result<Project>.Ok(project);
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> UpdateProjectAsync(int id, ProjectUpdateForm form)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == id);
            if (projectEntity == null)
                return Result.NotFound("project was not found.");

            ProjectFactory.Update(projectEntity, form);
            
            var result = await _projectRepository.UpdateAsync(projectEntity);
            return result ? Result.Ok() : Result.Error("Unable to update project.");
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }

    public async Task<IResult> DeleteProjectAsync(int id)
    {
        try
        {
            var projectEntity = await _projectRepository.GetAsync(x => x.ProjectId == id);
            if (projectEntity == null)
                return Result.NotFound("project was not found.");

            var result = await _projectRepository.DeleteAsync(projectEntity);
            return result ? Result.Ok() : Result.Error("Unable to delete project.");
        }
        catch (Exception ex)
        {
            Debug.Write(ex.Message);
            return Result.Error(ex.Message);
        }
    }
}
