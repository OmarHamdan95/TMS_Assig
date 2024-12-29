using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record CountMyTaskDashboardRequest : IRequest<Result<DashbordMyTaskModel>>;
