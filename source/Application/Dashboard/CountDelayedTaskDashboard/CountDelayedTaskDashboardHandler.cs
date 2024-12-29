using AjKpi.Application.Common;
using AjKpi.Model.Dashboard;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record CountDelayedTaskDashboardHandler : IRequestHandler<CountDelayedTaskDashboardRequest, Result<DashbordDelayedModel>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;
    public CountDelayedTaskDashboardHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService)
    {
        _kpiRepository = kpiRepository;
        _currentUserService = currentUserService;
    }


    public async Task<Result<DashbordDelayedModel>> Handle(CountDelayedTaskDashboardRequest request, CancellationToken cancellationToken)
    {

        DashbordDelayedModel data = new DashbordDelayedModel();
        string currentUserDepartmentCode = _currentUserService?.DepartmentCode;
        string currentUserRoleCode = _currentUserService?.RoleCode;

        var query = _kpiRepository.Queryable.AsNoTracking();

        if (currentUserDepartmentCode != Constant.StrategyDepartmentCode)
        {
            data.Delayed = await
                query.Where(_ => _.OwnerDepartemnt.Code == currentUserDepartmentCode &&
                                 _.KpiTasks.Any(_ => _.StartDate <= DateTimeOffset.UtcNow && _.EndDate >= DateTimeOffset.UtcNow && _.ResultValue == null)).CountAsync();
            data.Count = await query.Where(_ => _.OwnerDepartemnt.Code == currentUserDepartmentCode &&  _.Status.Code.ToLower() == Constant.Approved.ToLower()).CountAsync();
        }
        else
        {
            data.Delayed = await
                query.Where(_ => _.KpiTasks.Any(_ => _.StartDate <= DateTimeOffset.UtcNow && _.EndDate >= DateTimeOffset.UtcNow && _.ResultValue == null)).CountAsync();

            data.Count = await query.Where(_=>  _.Status.Code.ToLower() == Constant.Approved.ToLower()).CountAsync();
        }



        return new Result<DashbordDelayedModel>(OK, data);
    }
}
