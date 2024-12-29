using AjKpi.Application.Common;
using Microsoft.IdentityModel.Tokens;
using static System.Net.HttpStatusCode;
using Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace AjKpi.Application;

public sealed record GridKpiActiveResultListHandler : IRequestHandler<GridKpiActiveResultListRequest, Result<Grid<KpiGridModel>>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IRepositoryBase<Department> _departmentRepository;

    public GridKpiActiveResultListHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService, IRepositoryBase<Department> departmentRepository) =>
        (_kpiRepository, _currentUserService, _departmentRepository) = (kpiRepository, currentUserService, departmentRepository);

    public async Task<Result<Grid<KpiGridModel>>> Handle(GridKpiActiveResultListRequest request , CancellationToken cancellationToken)
    {

        string departmentIdString = _currentUserService?.DepartmentId;
        long departmentId = 0;
        long.TryParse(departmentIdString, out departmentId);
        string roleIdString = _currentUserService?.RoleId;
        long roleId = 0;
        long.TryParse(roleIdString, out roleId);

        var curentUserDepratment = await _departmentRepository.Queryable.Where(x => x.Id == departmentId).FirstOrDefaultAsync();


        var kpiQuery = _kpiRepository.Queryable.Where(_=> _.KpiTasks.Any(_=> _.StartDate <= DateTimeOffset.UtcNow && _.EndDate >= DateTimeOffset.UtcNow));

        if (request.Filters.Any())
        {
            foreach (var filter in request.Filters)
            {
                if (filter.Property == nameof(Kpi.StatusId) && filter.Value.IsNullOrEmpty())
                {
                    long.TryParse(filter.Value, out long result);
                    kpiQuery = kpiQuery.Where(x => x.StatusId == result);
                }

                if (filter.Property == nameof(Kpi.NameAr) && filter.Value.IsNullOrEmpty())
                {
                    kpiQuery = kpiQuery.Where(x => x.NameAr.Contains(filter.Value));
                }

                if (filter.Property == nameof(Kpi.NameEn) && filter.Value.IsNullOrEmpty())
                    kpiQuery = kpiQuery.Where(x => x.NameEn.Contains(filter.Value));

                if (filter.Property == nameof(Kpi.Number) && filter.Value.IsNullOrEmpty())
                    kpiQuery = kpiQuery.Where(x => x.Number.Contains(filter.Value));

                if (filter.Property == nameof(Kpi.KpiTypeId) && filter.Value.IsNullOrEmpty())
                {
                    long.TryParse(filter.Value, out long result);
                    kpiQuery = kpiQuery.Where(x => x.TypeId == result);
                }
            }
        }

        kpiQuery = kpiQuery.Where(
           x =>
           x.Status.Code.ToLower() == Constant.Approved.ToLower()
       );


        var data = kpiQuery.Select(x => new KpiGridModel()
        {
            Type = new LookupValueModel()
            {
                Code = x.Type.Code,
                NameAr = x.Type.NameAr,
                NameEn = x.Type.NameEn,
                Id = x.Type.Id
            },
            Id = x.Id,
            OwnerDepartemntId = x.OwnerDepartemntId,
            Number = x.Number,
            Status = new LookupValueModel()
            {
                Code = x.Status.Code,
                NameAr = x.Status.NameAr,
                NameEn = x.Status.NameEn,
                Id = x.Status.Id
            },
            NameAr = x.NameAr,
            NameEn = x.NameEn,
            StatusId = x.StatusId,
            EndDate = x.EndDate,
            KpiType = new LookupValueModel()
            {
                Code = x.KpiType.Code,
                NameAr = x.KpiType.NameAr,
                NameEn = x.KpiType.NameEn,
                Id = x.KpiType.Id
            },
            OwnerDepartemnt = new LookupValueModel()
            {
                Code = x.OwnerDepartemnt.Code,
                NameAr = x.OwnerDepartemnt.NameAr,
                NameEn = x.OwnerDepartemnt.NameEn,
                Id = x.OwnerDepartemnt.Id
            },
            RequestId = x.RequestId,
            TypeId = x.TypeId,
            KpiTypeId = x.KpiTypeId,
            StartDate = x.StartDate
        });


        var grid = new Grid<KpiGridModel>(data, request);

        return new Result<Grid<KpiGridModel>>(grid is null ? NotFound : OK, grid);
    }

}
