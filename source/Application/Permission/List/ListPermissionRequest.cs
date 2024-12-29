using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListPermissionRequest : IRequest<Result<IEnumerable<PermissionModel>>>;
