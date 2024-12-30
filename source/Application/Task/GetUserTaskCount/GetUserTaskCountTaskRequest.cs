using TMS.Model;
using TaskStatus = TMS.Domain.TaskStatus;

namespace TMS.Application;

public sealed record GetUserTaskCountTaskRequest() : IRequest<Result<IEnumerable<TaskModelPRCCount>>>;
