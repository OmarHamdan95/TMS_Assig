using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record CountKpiByDepDashboardRequest(DateTime? CreatedDateFrom =null, DateTime? CreatedDateTo =null) : IRequest<Result<List<DashbordKpiByDepModel>>>;
