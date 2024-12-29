using AjKpi.Application.Common;
using AjKpi.Model.Dashboard;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record CountMyTaskDashboardHandler : IRequestHandler<CountMyTaskDashboardRequest, Result<DashbordMyTaskModel>>
{
    private readonly IWFRepositoryBase<Request> _requestRepository;
    private readonly ICurrentUserService _currentUserService;
    public CountMyTaskDashboardHandler(IWFRepositoryBase<Request> requestRepository, ICurrentUserService currentUserService)
    {
        _requestRepository = requestRepository;
        _currentUserService = currentUserService;
    }


    public async Task<Result<DashbordMyTaskModel>> Handle(CountMyTaskDashboardRequest request, CancellationToken cancellationToken)
    {

        DashbordMyTaskModel data = new DashbordMyTaskModel();
        string currentUserDepartmentCode = _currentUserService?.DepartmentCode;
        string currentUserRoleCode = _currentUserService?.RoleCode;

        var query = _requestRepository.Queryable.AsNoTracking();

        data.Completed = await query.Where(_ =>_.CreatedBy == _currentUserService.UserName).CountAsync();

        if (currentUserDepartmentCode != Constant.StrategyDepartmentCode)
            data.Active = await query.Where(_ => _.InitDepartmentCode == currentUserDepartmentCode && _.TargetRoleCode == currentUserRoleCode)
                .CountAsync();
        else
            data.Active = await query.Where(_ => _.TargetRoleCode == currentUserRoleCode)
                .CountAsync();



        return new Result<DashbordMyTaskModel>(OK, data);
    }
}
