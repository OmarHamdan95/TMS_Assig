using System.Data;
namespace TMS.Domain;

public class Task : BaseAuditableEntity , IAggregateRoot
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public TaskStatus? Status { get; set; }
    public TaskPriority? Priority { get; set; }
    public DateTime? DueDate { get; set; }
    public User? AssignedTo { get; set; }
    public long? AssignedToId { get; set; }


    public Task(string? title, string? description, TaskStatus? status, TaskPriority? priority, DateTime? dueDate, long? assignedToId)
    {
        Title = title;
        Description = description;
        Status = status;
        Priority = priority;
        DueDate = dueDate;
        AssignedToId = assignedToId;
    }



    public void Update(string? title, string? description)
    {
        Title = title;
        Description = description;
    }

    public void UpdateStatus(long? statusId) => Status = (TaskStatus)statusId;

    public void UpdatePriority(long? priorityId) => Priority = (TaskPriority)priorityId;

    public void UpdateDueDate(DateTime? dueDate) => DueDate = dueDate;

    public void UpdateAssignedTo(long? assignedToId) => AssignedToId = assignedToId;
}
