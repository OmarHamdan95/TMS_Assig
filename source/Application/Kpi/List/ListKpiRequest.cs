namespace AjKpi.Application;

public sealed record ListKpiRequest : IRequest<Result<IEnumerable<KpiModel>>>;
