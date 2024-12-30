using TMS.Model;
using TaskStatus = TMS.Domain.TaskStatus;

namespace TMS.Application;

public sealed record GetTaskDueDateRequest() : IRequest<Result<IEnumerable<TaskModelPRC>>>;
