using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Api.Models;

namespace ProjectFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase {
    private static readonly List<Project> projects = new();

    [HttpPost]
    public IActionResult Create(Project project){
        projects.Add(project);
        return Ok(project);
    }

    [HttpGet]
    public IActionResult GetAll() {
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id) {
        foreach (Project project in projects){
            if (project.Id == id){return Ok(project);}
        }
        return NotFound();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] string newName){
        foreach (Project project in projects){
            if (project.Id == id) {
                project.Name = newName;
                return Ok(project);}
            }
        return NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id){
        foreach (Project project in projects){
            if (project.Id == id) {
                projects.Remove(project);
                return NoContent();}
        }

        return NotFound();
    }

}

