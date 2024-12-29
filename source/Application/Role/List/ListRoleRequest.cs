using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListRoleRequest : IRequest<Result<IEnumerable<RoleModel>>>;
