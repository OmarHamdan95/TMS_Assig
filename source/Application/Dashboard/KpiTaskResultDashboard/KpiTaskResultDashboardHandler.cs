using AjKpi.Application.Common;
using AjKpi.Model.Dashboard;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record KpiTaskResultDashboardHandler : IRequestHandler<KpiTaskResultDashboardRequest, Result<List<DashbordKpiTaskResultModel>>>
{
    private readonly IRepositoryBase<KpiTask> _kpiTaskRepository;
    private readonly ICurrentUserService _currentUserService;
    public KpiTaskResultDashboardHandler(IRepositoryBase<KpiTask> kpiTaskRepository, ICurrentUserService currentUserService)
    {
        _kpiTaskRepository = kpiTaskRepository;
        _currentUserService = currentUserService;
    }


    public async Task<Result<List<DashbordKpiTaskResultModel>>> Handle(KpiTaskResultDashboardRequest request, CancellationToken cancellationToken)
    {

        var query = _kpiTaskRepository.Queryable.AsNoTracking();

        if(request.KpiId.HasValue)
            query = query.Where(k => k.KpiId == request.KpiId);

        var data = await query.Select(k => new DashbordKpiTaskResultModel()
        {
            Target = k.Target,
            Result = k.ResultValue,
            EndDate = k.EndDate,
            StartDate = k.StartDate,
        }).ToListAsync();


        return new Result<List<DashbordKpiTaskResultModel>>(OK, data);
    }
}
