using AjKpi.Application.Common;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record CountWfStageByStepDashboardHandler : IRequestHandler<CountWfStageByStepDashboardRequest, Result<long>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;
    public CountWfStageByStepDashboardHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService)
    {
        _kpiRepository = kpiRepository;
        _currentUserService = currentUserService;
    }


    public async Task<Result<long>> Handle(CountWfStageByStepDashboardRequest request, CancellationToken cancellationToken)
    {
        var query = _kpiRepository.Queryable;

        if (request.stepCode == Constant.DepManagerStepCode)
            query = query.Where(x => x.Reqeust.Status.Code == Constant.SubmitStepCode ||
                                     x.Reqeust.Status.Code == Constant.ResubmitStepCode ||
                                     x.Reqeust.Status.Code == Constant.ReturnForUpdateByStgAudStepCode);

        else if (request.stepCode == Constant.StgAudStepCode)
            query = query.Where(x => x.Reqeust.Status.Code == Constant.ReturnForUpdateByStgManagerStepCode ||
                                     x.Reqeust.Status.Code == Constant.ApprovedByDepManagerStepCode);
        else
            query = query.Where(x => x.Reqeust.Status.Code == request.stepCode);;

        var curentUserDepartmentCode = _currentUserService.DepartmentCode;


        if (curentUserDepartmentCode != Constant.StrategyDepartmentCode)
            query = query.Where(x => x.OwnerDepartemnt.Code == curentUserDepartmentCode);

        var data = await query.AsNoTracking().CountAsync();

        return new Result<long>(OK, data);
    }
}
