namespace AjKpi.Application;

public sealed record DeleteRoleRequest(long Id) : IRequest<Result>;
