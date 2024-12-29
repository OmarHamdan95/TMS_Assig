using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridKpiActiveResultListRequest : GridParameters , IRequest<Result<Grid<KpiGridModel>>>;
