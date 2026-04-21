using Microsoft.AspNetCore.Mvc;
using TaskManager.Api.DTOs;
using TaskManager.Api.Entities;
using TaskManager.Api.Responses;
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
        return Ok(ApiResponse<List<TaskItem>>.SuccessResponse(tasks));
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateTaskDto dto)
    {
        var created = await _service.Create(dto);
        return Ok(ApiResponse<TaskItem>.SuccessResponse(created));
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateTaskDto dto)
    {
        var updated = await _service.Update(id, dto);

        if (updated == null)
            return NotFound(ApiResponse<TaskItem>.ErrorResponse(new List<string> { "Tarefa não encontrada." }));

        return Ok(ApiResponse<TaskItem>.SuccessResponse(updated));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _service.Delete(id);

        if (!deleted)
            return NotFound(ApiResponse<string>.ErrorResponse(new () { "Tarefa não encontrada." }));

        return Ok(ApiResponse<string>.SuccessResponse("Tarefa removida com sucesso."));
    }

    [HttpGet("status/{status}")]
    public async Task<IActionResult> GetByStatus(string status)
    {
        var tasks = await _service.GetByStatus(status);
        return Ok(ApiResponse<List<TaskItem>>.SuccessResponse(tasks));
    }
}

