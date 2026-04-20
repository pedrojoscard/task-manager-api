using TaskManager.Api.Data;
using TaskManager.Api.Entities;
using Microsoft.EntityFrameworkCore;
using TaskManager.Api.Enums;
using System.Runtime.InteropServices;
using TaskManager.Api.DTOs;

namespace TaskManager.Api.Services;

public class TaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> GetAll()
    {
        return _context.Tasks.ToList();
    }

    public async Task<TaskItem> Create(CreateTaskDto dto)
    {
        var task = new TaskItem
        {
            Title = dto.Title,
            Description = dto.Description,
            Status = TaskStatusEnum.Todo
        };

        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> Update(int id, UpdateTaskDto dto)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return null;

        task.Title = dto.Title;
        task.Description = dto.Description;

        if (Enum.TryParse<TaskStatusEnum>(dto.Status, true, out var status))
            task.Status = status;

        await _context.SaveChangesAsync();

        return task;
    }

    public async Task<bool> Delete(int id)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();

        return true;
    }

    public async Task<List<TaskItem>> GetByStatus(string status)
    {
        if (!Enum.TryParse<TaskStatusEnum>(status, true, out var parsedStatus))
            return new List<TaskItem>();

        return await _context.Tasks.Where(t => t.Status == parsedStatus).ToListAsync();
    }
}