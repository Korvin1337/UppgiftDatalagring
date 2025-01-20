using Microsoft.AspNetCore.Mvc;
using Business.Interfaces;
using Business.Dtos;

namespace Presentation2.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController(IProjectService projectService) : ControllerBase
{
    private readonly IProjectService _projectService = projectService;

    [HttpPost]
    public IActionResult Create(ProjectRegistrationForm form)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = _projectService.CreateProject(form);
            return Ok(result);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        try
        {
            var projects = _projectService.GetAllProjects();
            return Ok(projects);
        } catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
