using AjKpi.Application.Common;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record CountKpiTaskDashboardHandler : IRequestHandler<CountKpiTaskDashboardRequest, Result<long>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;
    public CountKpiTaskDashboardHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService)
    {
        _kpiRepository = kpiRepository;
        _currentUserService = currentUserService;
    }


    public async Task<Result<long>> Handle(CountKpiTaskDashboardRequest request, CancellationToken cancellationToken)
    {
        string currentUserDepartmentIdString = _currentUserService?.DepartmentId;
        long departmentId = 0;
        long.TryParse(currentUserDepartmentIdString, out departmentId);

        var data = await _kpiRepository.Queryable.Where(
            x =>
                x.KpiTasks.Any(_ => _.StartDate <= DateTimeOffset.UtcNow && _.EndDate >= DateTimeOffset.UtcNow)
                && x.OwnerDepartemntId == departmentId
        ).AsNoTracking().CountAsync();


        return new Result<long>(OK, data);
    }
}
