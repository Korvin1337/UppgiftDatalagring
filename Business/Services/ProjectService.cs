using Business.Interfaces;
using Data.Contexts;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services;

public class ProjectService(DataContext context) : IProjectService
{
    private readonly DataContext _context = context;

    public ProjectEntity CreateProject(ProjectEntity projectEntity)
    {
        try {
            _context.Projects.Add(projectEntity);
            _context.SaveChanges();

            return projectEntity;
        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }
    }

    public IEnumerable<ProjectEntity> GetProjects()
    {
        try {
            return _context.Projects;
        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }
    }

    public ProjectEntity GetProjectById(int id)
    {
        try {
            var projectEntity = _context.Projects.FirstOrDefault(x => x.ProjectId == id);

            return projectEntity ?? null!;
        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }

            
    }

    public ProjectEntity UpdateProject(ProjectEntity projectEntity)
    {
        try {
            _context.Projects.Update(projectEntity);
            _context.SaveChanges();

            return projectEntity;
        } catch (Exception ex) {
            Debug.Write(ex);
            return null!;
        }

    }

    public bool DeleteProjectById(int id) /* Use ProjectEntity projectEntity if needed */
    {
        try {
            var projectEntity = _context.Projects.FirstOrDefault(x => x.ProjectId == id);

            if (projectEntity != null)
            {
                context.Remove(projectEntity);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        } catch (Exception ex) {
            Debug.Write(ex);
            return false!;
        }
    }
}
