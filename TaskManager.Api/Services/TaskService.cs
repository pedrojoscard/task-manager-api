using TaskManager.Api.Data;
using TaskManager.Api.Entities;
using Microsoft.EntityFrameworkCore;

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

    public async Task<TaskItem> Create(TaskItem task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return task;
    }

    public async Task<TaskItem?> Update(int id, TaskItem updatedTask)
    {
        var task = await _context.Tasks.FindAsync(id);

        if (task == null)
            return null;

        task.Title = updatedTask.Title;
        task.Description = updatedTask.Description;
        task.Status = updatedTask.Status;

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
        return await _context.Tasks.Where(t => t.Status == status).ToListAsync();
    }
}