namespace TaskManager.Api.Entities;
using TaskManager.Api.Enums;

public class TaskItem
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public TaskStatusEnum Status { get; set; } = TaskStatusEnum.Todo;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}
