using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridKpiTaskListResultRequest : GridParameters , IRequest<Result<Grid<KpiTaskListResult>>>;
