namespace AjKpi.Application;

public sealed record DeletePermissionRequest(long Id) : IRequest<Result>;
