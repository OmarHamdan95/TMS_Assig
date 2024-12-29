using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetRoleRequest(long Id) : IRequest<Result<RoleModel>>;
