using AjKpi.Model.Dashboard;
namespace AjKpi.Application;

public sealed record CountDoneTaskDashboardRequest : IRequest<Result<DashbordDoneTaskModel>>;
