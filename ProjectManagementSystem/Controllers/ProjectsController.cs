using System.Diagnostics;
using DataAccess.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Domain.Entities.project;
using ProjectManagementSystem.DtoObjects.Projects;

namespace ProjectManagementSystem.Controllers;

[Route("api/projects")]
[ApiController]
public class ProjectsController : ControllerBase
{
    private readonly DataContext _context;

    public ProjectsController(DataContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<ResponseProjectDto>> Get()
    {

        try
        {
            var projects = await _context.Projects.ToListAsync();
            var response = new List<Project>();
            foreach (var project in projects)
            {
                response.Add(new Project()
                {
                    Name = project.Name,
                    Description = project.Description,
                    DeadLine = project.DeadLine,
                    StartDate = project.StartDate,
                    Status = project.Status
                });
            }

            return Ok(response);
        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ResponseProjectDto>> Get(int id)
    {

        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);
            var response = new ResponseProjectDto()
            {
                Name = project.Name,
                Description = project.Description,
                DeadLine = project.DeadLine,
                StartDate = project.StartDate,

                Status = project.Status
            };
            return Ok(response);
        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }
        
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody]CreateProjectDto project)
    {
        try
        {
            if (project==null)
            {
                return BadRequest();
            }

            await _context.Projects.AddAsync(new Project()
            {
                Name = project.Name,
                Description = project.Description,
                DeadLine = project.DeadLine,
                StartDate = project.StartDate,
                Status = project.Status,
            });
            await _context.SaveChangesAsync();

            return CreatedAtAction("Get", project);
        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody]UpdateProjectDto project)
    {

        if (id<=0)
        {
            return BadRequest();
        }

        var projectForUpdate = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        projectForUpdate.Name= project.Name;
        projectForUpdate.Description= project.Description;
        projectForUpdate.DeadLine= project.DeadLine;
        projectForUpdate.StartDate= project.StartDate;
        projectForUpdate.Status = project.Status;

        await _context.SaveChangesAsync();

        return Ok(project);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var projectForRemove = await _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

            if (projectForRemove == null)
                return NotFound();

            _context.Projects.Remove(projectForRemove);

            await _context.SaveChangesAsync();

            return Ok("Deleted");
        }
        catch
        {
            return StatusCode(500, "Internal Server Error");
        }

    }
}