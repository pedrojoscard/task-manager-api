using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.Entities;
using TaskManager.Api.Services;

namespace TaskManager.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    private readonly TaskService _service;

    public TaskController(TaskService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var tasks = await _service.GetAll();
        return Ok(tasks);
    }

    [HttpPost]
    public async Task<IActionResult> Create(TaskItem task)
    {
        var created = await _service.Create(task);
        return Ok(created);
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, TaskItem task)
    {
        var updated = await _service.Update(id, task);

        if (updated == null)
            return NotFound();

        return Ok(updated);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deletd = await _service.Delete(id);

        if (!deletd)
            return NotFound();

        return NoContent();
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(string status)
    {
        var tasks = await _service.GetByStatus(status);
        return Ok(tasks);
    }
}

