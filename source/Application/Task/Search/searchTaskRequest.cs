using TMS.Model;
using TaskStatus = TMS.Domain.TaskStatus;

namespace TMS.Application;

public sealed record SearchTaskRequest (
    TaskStatus? Status, TaskPriority? Priority, DateTime? DueDate , string? orderBy, int pageIndex, int pageSize) :
    IRequest<Result<Grid<TaskModel>>>;
