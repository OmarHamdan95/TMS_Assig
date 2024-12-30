using TMS.Model;

namespace TMS.Application;

public sealed record GetTaskRequest(long Id) : IRequest<Result<TaskModel>>;
