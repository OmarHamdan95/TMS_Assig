using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridKpiRequest : GridParameters , IRequest<Result<Grid<KpiGridModel>>>;
