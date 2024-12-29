namespace AjKpi.Application;

public sealed record DeleteKpiRequest(long Id) : IRequest<Result>;
