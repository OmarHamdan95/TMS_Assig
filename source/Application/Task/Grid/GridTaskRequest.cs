using TMS.Model;

namespace TMS.Application;

public sealed record GridTaskRequest : GridParameters , IRequest<Result<Grid<TaskModel>>>;
