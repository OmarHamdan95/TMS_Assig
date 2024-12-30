using TMS.Model.Enum;
using TaskStatus = TMS.Model.Enum.TaskStatus;
namespace TMS.Model;

public sealed record TaskModel
{
    public long? Id { get; init; }
    public string? Title { get; init; }
    public long? Status { get; init; }
    public long? Priority { get; init; }
    public string? Description { get; set; }
    public DateTime? DueDate { get; set; }
    public UserModel? AssignedTo { get; set; }
    public long? AssignedToId { get; set; }
}


public sealed record TaskModelPRC
{
    public long? Id { get; init; }
    public string? Title { get; init; }
    public long? Status { get; init; }
    public long? Priority { get; init; }
    public string? Description { get; set; }
    public long? AssignedToId { get; set; }
    public DateTime? DueDate { get; set; }

}

public sealed record TaskModelPRCCount
{
    public long? AssignedToId { get; set; }
    public string? UserName { get; set; }
    public long? TaskCount { get; set; }
    public long? CompletedTasks { get; set; }
}
