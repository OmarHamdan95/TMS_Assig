using System.Text.Json.Serialization;
using TaskStatus = TMS.Domain.TaskStatus;
namespace TMS.Application;

public sealed record UpdateTaskRequest(string? Title , string? Description , TaskStatus? Status, TaskPriority? Priority, DateTime? DueDate,
    long? AssignedToId) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
