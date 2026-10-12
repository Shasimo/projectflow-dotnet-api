
using Microsoft.AspNetCore.Mvc;
using ProjectFlow.Models;

namespace ProjectFlow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private static readonly List<Category> categories = new();
    private static int nextId = 1;

    // CREATE
    [HttpPost]
    public IActionResult Create(Category category)
    {
        category.Id = nextId++;
        categories.Add(category);

        return Ok(category);
    }

    // GET ALL
    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(categories);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        foreach (Category category in categories)
        {
            if (category.Id == id)
            {
                return Ok(category);
            }
        }

        return NotFound();
    }

    // UPDATE
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] string newName)
    {
        foreach (Category category in categories)
        {
            if (category.Id == id)
            {
                category.Name = newName;
                return Ok(category);
            }
        }

        return NotFound();
    }

    // DELETE
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        foreach (Category category in categories)
        {
            if (category.Id == id)
            {
                categories.Remove(category);
                return NoContent();
            }
        }

        return NotFound();
    }
}
