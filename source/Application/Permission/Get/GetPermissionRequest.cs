using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetPermissionRequest(long Id) : IRequest<Result<PermissionModel>>;
