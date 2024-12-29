using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridRoleRequest : GridParameters , IRequest<Result<Grid<RoleModel>>>;
