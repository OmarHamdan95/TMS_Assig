using AjKpi.Application.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Shared.Common;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record TaskKpiHandler : IRequestHandler<TaskKpiRequest, Result<Grid<KpiGridModel>>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly IRepositoryBase<Department> _departmentRepository;
    private readonly IRepositoryBase<Role> _roleRepository;
    private readonly ICurrentUserService _currentUserService;


    public TaskKpiHandler(IRepositoryBase<Kpi> kpiRepository, ICurrentUserService currentUserService , IRepositoryBase<Department> departmentRepository , IRepositoryBase<Role> roleRepository) =>
        (_kpiRepository, _currentUserService , _departmentRepository , _roleRepository) = (kpiRepository, currentUserService , departmentRepository , roleRepository);

    public async Task<Result<Grid<KpiGridModel>>> Handle(TaskKpiRequest request, CancellationToken cancellationToken)
    {
        long.TryParse(_currentUserService?.DepartmentId, out long departmentId);

        var curentUserDepratment = await _departmentRepository.Queryable.Where(x => x.Id == departmentId).FirstOrDefaultAsync();

        var kpiQuery = _kpiRepository.Queryable;


        if (request.Filters.Any())
        {
            foreach (var filter in request.Filters)
            {
                if (filter.Property == nameof(Kpi.StatusId) && filter.Value.IsNullOrEmpty())
                {
                    long.TryParse(filter.Value, out long result);
                    kpiQuery = kpiQuery.Where(x => x.StatusId == result);
                }


                if (filter.Property == nameof(Kpi.CreatedDate) && filter.Value.IsNullOrEmpty())
                {
                    DateTime.TryParse(filter.Value, out DateTime result);
                    if (filter.Comparison == ">=")
                        kpiQuery = kpiQuery.Where(x => x.CreatedDate >= result);
                    if (filter.Comparison == "<=")
                        kpiQuery = kpiQuery.Where(x => x.CreatedDate <= result);
                }

                if (filter.Property == nameof(Kpi.StartDate) && filter.Value.IsNullOrEmpty())
                {
                    DateTime.TryParse(filter.Value, out DateTime result);
                    if (filter.Comparison == ">=")
                        kpiQuery = kpiQuery.Where(x => x.StartDate >= result);
                    if (filter.Comparison == "<=")
                        kpiQuery = kpiQuery.Where(x => x.StartDate <= result);
                }

                if (filter.Property == nameof(Kpi.EndDate) && filter.Value.IsNullOrEmpty())
                {
                    DateTime.TryParse(filter.Value, out DateTime result);
                    if (filter.Comparison == ">=")
                        kpiQuery = kpiQuery.Where(x => x.EndDate >= result);
                    if (filter.Comparison == "<=")
                        kpiQuery = kpiQuery.Where(x => x.EndDate <= result);
                }

                if (filter.Property == nameof(Kpi.NameAr) && filter.Value.IsNullOrEmpty())
                {
                    kpiQuery= kpiQuery.Where(x => x.NameAr.Contains(filter.Value));
                }

                if (filter.Property == nameof(Kpi.NameEn) && filter.Value.IsNullOrEmpty())
                    kpiQuery= kpiQuery.Where(x => x.NameEn.Contains(filter.Value));

                if (filter.Property == nameof(Kpi.Number) && filter.Value.IsNullOrEmpty())
                    kpiQuery= kpiQuery.Where(x => x.Number.Contains(filter.Value));

                if (filter.Property == nameof(Kpi.KpiTypeId) && filter.Value.IsNullOrEmpty())
                {
                    long.TryParse(filter.Value, out long result);
                    kpiQuery = kpiQuery.Where(x => x.TypeId == result);
                }
            }
        }

        kpiQuery = kpiQuery.Where(
            x =>
            x.Status.Code.ToLower() != Constant.Approved.ToLower()
         && x.Status.Code.ToLower() != Constant.Draft.ToLower()
         && x.Status.Code.ToLower() != Constant.Rejected.ToLower()
         && x.Reqeust.TargetRoleCode.ToLower().Trim() == _currentUserService.RoleCode.ToLower().Trim()
         && x.Reqeust.TargetDepartmentCode.ToLower().Trim() == _currentUserService.DepartmentCode.ToLower().Trim()
        );

        // if (curentUserDepratment is not null &&  curentUserDepratment.Code?.ToLower() == Constant.StrategyDepartment.ToLower()
        //     && _currentUserService?.RoleCode?.ToLower() == Constant.HeadOfDepartment.ToLower())
        //     kpiQuery = kpiQuery.Where(x =>
        //         (x.Status.Code.ToLower() == Constant.InProgress.ToLower() ||
        //          x.Status.Code.ToLower() == Constant.ReSubmitted.ToLower())
        //         && x.Reqeust.Status.Code.ToLower() == Constant.ApprovedByDepManager.ToLower());
        //
        // else if(_currentUserService?.RoleCode?.ToLower() == Constant.HeadOfDepartment.ToLower())
        //     kpiQuery = kpiQuery.Where(x =>
        //         (x.Status.Code.ToLower() == Constant.Submitted.ToLower() ||
        //          x.Status.Code.ToLower() == Constant.ReSubmitted.ToLower() ||
        //          x.Status.Code.ToLower() == Constant.ReturnForUpdate.ToLower()) &&
        //         x.OwnerDepartemntId == curentUserDepratment.Id &&
        //         (x.Reqeust.Status.Code.ToLower() == Constant.New.ToLower() ||
        //          x.Reqeust.Status.Code.ToLower() == Constant.ResubmittedFromDataEntry.ToLower() ||
        //          x.Reqeust.Status.Code.ToLower() == Constant.ReturendForUpdatesByStgManager.ToLower()) );
        //
        // else if(_currentUserService?.RoleCode?.ToLower() == Constant.DataEntry.ToLower())
        //     kpiQuery = kpiQuery.Where(x =>
        //         (x.Status.Code.ToLower() == Constant.ReturnForUpdate.ToLower()) &&
        //         x.OwnerDepartemntId == curentUserDepratment.Id && x.Reqeust.Status.Code.ToLower() == Constant.ReturendForUpdatesByDepManager.ToLower());
        // else
        //     return new Result<Grid<KpiGridModel>>( NotFound , new Grid<KpiGridModel>(null,request));

        var data =  kpiQuery.Select(x=> new KpiGridModel()
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
            MeasurementCycle = new LookupValueModel()
            {
                Code = x.MeasurementCycle.Code,
                NameAr = x.MeasurementCycle.NameAr,
                NameEn = x.MeasurementCycle.NameEn,
                Id = x.MeasurementCycle.Id
            },
            MeasurementCycleId = x.MeasurementCycleId,
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
            StartDate = x.StartDate,
            CreatedDate = x.CreatedDate
        });

        var grid = new Grid<KpiGridModel>(data ,request);

        return new Result<Grid<KpiGridModel>>(grid is null ? NotFound : OK, grid);
    }
}
