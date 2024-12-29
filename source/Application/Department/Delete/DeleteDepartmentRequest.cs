namespace AjKpi.Application;

public sealed record DeleteDepartmentRequest(long Id) : IRequest<Result>;
