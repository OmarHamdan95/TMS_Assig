namespace AjKpi.Application;

public sealed record InactivateDepartmentRequest(long Id) : IRequest<Result>;
