using Business.Dtos;
using Business.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Factories;

public class ProjectFactory
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
        StatusId = form.StatusId
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
        StatusId = entity.StatusId
    };

    public static ProjectUpdateForm Create(Project project) => new()
    {
        ProjectName = project.ProjectName,
        StartDate = project.StartDate,
        EndDate = project.EndDate,
        ProjectManager = project.ProjectManager,
        CustomerId = project.CustomerId,
        TotalCost = project.TotalCost,
        StatusId = project.StatusId
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
        StatusId = form.StatusId
    };

    public static void Update(ProjectEntity projectEntity, ProjectUpdateForm form)
    {
        projectEntity.ProjectName = form.ProjectName;
        projectEntity.StartDate = form.StartDate;
        projectEntity.EndDate = form.EndDate;
        projectEntity.ProjectManager = form.ProjectManager;
        projectEntity.CustomerId = form.CustomerId;
        projectEntity.TotalCost = form.TotalCost;
        projectEntity.StatusId = form.StatusId;
    }

}
