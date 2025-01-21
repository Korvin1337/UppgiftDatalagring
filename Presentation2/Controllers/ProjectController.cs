using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Dtos;
using Business.Services;

namespace Presentation2.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(ProjectRegistrationForm form)
    {
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (await _projectService.AlreadyExistsAsync(x => x.ProjectName == form.ProjectName))
                    {
                        return Conflict("Project with same name already excists");
                    }

                    var project = await _projectService.CreateProjectAsync(form);
                    if (project != null)
                    {
                        return Ok(project);
                    }
                    return Ok(project);
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }

        [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var projects = await _projectService.GetAllProjectsAsync();
            return Ok(projects);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
