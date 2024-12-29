using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record CountDelayedTaskDashboardRequest : IRequest<Result<DashbordDelayedModel>>;
