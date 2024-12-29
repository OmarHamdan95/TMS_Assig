using AjKpi.Model;

namespace AjKpi.Application;

public sealed record TaskKpiRequest : GridParameters , IRequest<Result<Grid<KpiGridModel>>>;
