namespace AjKpi.Application;

public sealed record InactivateRoleRequest(long Id) : IRequest<Result>;
