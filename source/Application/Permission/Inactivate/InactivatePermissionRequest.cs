namespace AjKpi.Application;

public sealed record InactivatePermissionRequest(long Id) : IRequest<Result>;
