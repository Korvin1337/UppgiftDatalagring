using Business.Dtos;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories;

public static class ProjectFactory
{
    public static ProjectRegistrationForm Create() => new();


    public static ProjectEntity Create(ProjectRegistrationForm form) => new()
    {
        ProjectName = form.ProjectName,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ProjectManager = form.ProjectManager,
        CustomerId = form.CustomerId,
        TotalCost = form.TotalCost,
        Status = form.Status
    };

    public static Project Create(ProjectEntity entity) => new()
    {
        ProjectId = entity.ProjectId,
        ProjectName = entity.ProjectName,
        StartDate = entity.StartDate,
        EndDate = entity.EndDate,
        ProjectManager = entity.ProjectManager,
        CustomerId = entity.CustomerId,
        TotalCost = entity.TotalCost,
        Status = entity.Status
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        ProjectName = project.ProjectName,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        ProjectManager = project.ProjectManager,
        CustomerId = project.CustomerId,
        TotalCost = project.TotalCost,
        Status = project.Status
    };

    public static ProjectEntity Create(ProjectEntity projectEntity, ProjectUpdateForm form) => new()
    {
        ProjectId = projectEntity.ProjectId,
        ProjectName = form.ProjectName,
        StartDate = form.StartDate,
        EndDate = form.EndDate,
        ProjectManager = form.ProjectManager,
        CustomerId = form.CustomerId,
        TotalCost = form.TotalCost,
        Status = form.Status
    };

}
