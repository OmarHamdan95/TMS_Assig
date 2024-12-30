using TaskStatus = TMS.Domain.TaskStatus;
namespace TMS.Application;

public sealed record AddTaskRequest(string? Title , string? Description , TaskStatus? Status, TaskPriority? Priority, DateTime? DueDate,
    long? AssignedToId) : IRequest<Result<long>>;
