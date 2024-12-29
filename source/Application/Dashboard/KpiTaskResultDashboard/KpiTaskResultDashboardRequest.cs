using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record KpiTaskResultDashboardRequest(long? KpiId =null) : IRequest<Result<List<DashbordKpiTaskResultModel>>>;
