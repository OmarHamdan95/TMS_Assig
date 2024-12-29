using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record RequestByStepDashboardRequest : IRequest<Result<List<DashbordRequestByStepModel>>>;
