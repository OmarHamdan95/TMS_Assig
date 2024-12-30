using TMS.Model;
using TaskStatus = TMS.Domain.TaskStatus;

namespace TMS.Application;

public sealed record GetTaskByStatusRequest(TaskStatus status) : IRequest<Result<IEnumerable<TaskModelPRC>>>;
