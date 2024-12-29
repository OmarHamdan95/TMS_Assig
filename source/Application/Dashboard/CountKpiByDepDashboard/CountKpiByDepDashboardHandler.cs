using AjKpi.Application.Common;
using AjKpi.Model.Dashboard;
using Microsoft.EntityFrameworkCore;
using Shared.Common;
namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record CountKpiByDepDashboardHandler : IRequestHandler<CountKpiByDepDashboardRequest, Result<List<DashbordKpiByDepModel>>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ILookupRepositoryBase<Department> _departmentRepository;
    private readonly ICurrentUserService _currentUserService;
    public CountKpiByDepDashboardHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService , ILookupRepositoryBase<Department> departmentRepository)
    {
        _kpiRepository = kpiRepository;
        _currentUserService = currentUserService;
        _departmentRepository = departmentRepository;
    }


    public async Task<Result<List<DashbordKpiByDepModel>>> Handle(CountKpiByDepDashboardRequest request, CancellationToken cancellationToken)
    {

        var query = _kpiRepository.Queryable.AsNoTracking();


        var departmentData = await _departmentRepository.Queryable.Where(_=> _.Code != "SystemAdmin").AsNoTracking().ToListAsync();


        if(request.CreatedDateFrom.HasValue)
            query = query.Where(k => k.CreatedDate >= request.CreatedDateFrom);

        if(request.CreatedDateTo.HasValue)
            query = query.Where(k => k.CreatedDate <= request.CreatedDateTo);

        var data = await query.Where(
            x =>
                x.Status.Code.ToLower() == Constant.Approved.ToLower()
        ).GroupBy(_ => new
        {
            id = _.OwnerDepartemnt.Id,
            name = _.OwnerDepartemnt.NameAr
        }).Select(k => new DashbordKpiByDepModel()
        {
            DepartmentName = k.Key.name,
            DepartmentID = k.Key.id,
            Count = k.Count()
        }).ToListAsync();


        foreach (var department in departmentData)
        {
            if(!data.Any(_=> _.DepartmentID == department.Id))
                data.Add(new DashbordKpiByDepModel() {DepartmentName = department.NameAr , DepartmentID = department.Id , Count = 0});
        }


        return new Result<List<DashbordKpiByDepModel>>(OK, data);
    }
}
