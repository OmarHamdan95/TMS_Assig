using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ActiveKpiRequest : GridParameters , IRequest<Result<Grid<KpiGridModel>>>;
