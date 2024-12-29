namespace AjKpi.Application;

public sealed record GetKpiRequest(long Id) : IRequest<Result<KpiResultModel>>;
