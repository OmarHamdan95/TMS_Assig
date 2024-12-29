using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridPermissionRequest : GridParameters , IRequest<Result<Grid<PermissionModel>>>;
