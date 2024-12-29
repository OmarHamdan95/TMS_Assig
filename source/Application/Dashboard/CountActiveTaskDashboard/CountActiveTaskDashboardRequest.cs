using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record CountActiveTaskDashboardRequest : IRequest<Result<DashbordTaskModel>>;
