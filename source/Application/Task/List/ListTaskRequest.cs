using TMS.Model;

namespace TMS.Application;

public sealed record ListTaskRequest : IRequest<Result<IEnumerable<TaskModel>>>;
