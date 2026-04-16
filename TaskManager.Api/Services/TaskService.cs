using TaskManager.Api.Data;
using TaskManager.Api.Entities;

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
}