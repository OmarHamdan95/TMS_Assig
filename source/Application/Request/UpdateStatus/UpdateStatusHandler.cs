using AjKpi.Application.Common;
using AjKpi.Database;
using AjKpi.Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Shared.Common;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdateRequestStatusHandler : IRequestHandler<UpdateRequestStatus, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IWFRepositoryBase<Request> _requestRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly IRepositoryBase<KpiTask> _kpiTaskRepository;
    private readonly ILookupRepositoryBase<LookupValue> _lookupValueRepository;
    private readonly IMediator _mediator;

    public UpdateRequestStatusHandler
    (
        IUnitOfWork unitOfWork,
        IWFRepositoryBase<Request> requestRepository,
        ICurrentUserService currentUserService,
        IRepositoryBase<Kpi> kpiRepository,
        ILookupRepositoryBase<LookupValue> lookupValueRepository,
        IRepositoryBase<KpiTask> kpiTaskRepository,
        IMediator mediator
    )
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
        _currentUserService = currentUserService;
        _kpiRepository = kpiRepository;
        _lookupValueRepository = lookupValueRepository;
        _mediator = mediator;
        _kpiTaskRepository = kpiTaskRepository;
    }

    public async Task<Result> Handle(UpdateRequestStatus command, CancellationToken cancellationToken)
    {
        var request = await _requestRepository.Queryable
            .Include(e => e.Status)
            .Include(e => e.Type.Statuses)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == command.RequestId) ?? throw new Exception("REQUEST_NOT_FOUND");


        var currentStatus = request.Status;
        if (currentStatus.IsEndState.HasValue && currentStatus.IsEndState.Value)
        {
            throw new Exception("REQUEST_ALREADY_COMPLETED");
        }

        //////
        /// Select From Table Wf Status where action = reqeust action and role = curentUserRole

        var newStatus = request.Type.Statuses
            .FirstOrDefault(s => s.Code == command.Status.Code) ?? throw new Exception("STATUS_NOT_FOUND");

        if (!currentStatus.NextStatusCodes.Any(code => code == newStatus.Code))
        {
            throw new Exception("INVALID_STATUS_CODE");
        }

        var isSelfAction = request.CreatedBy == _currentUserService?.UserName;

        if ((!currentStatus.SelfAllowed && isSelfAction) ||
            (currentStatus.Roles.Any() &&
             !currentStatus.Roles.Any(roleCode => roleCode == _currentUserService.RoleCode)))
        {
            throw new Exception("FORBIDDEN_ACTION");
        }


        var targetDepartmentCode =
            newStatus.DepartmentCode == "Init" ? request.InitDepartmentCode : newStatus.DepartmentCode;


        var kpi = await handleKpiStatus(request.ExternalId, newStatus, currentStatus, request.Id, command.Note);


        await _requestRepository.Queryable.Where(r => r.Id == request.Id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(x => x.StatusId, x => newStatus.Id)
                    .SetProperty(x => x.Note, x => command.Note)
                    .SetProperty(x => x.TargetDepartmentCode, x => targetDepartmentCode)
                    .SetProperty(x => x.TargetRoleCode, x => newStatus.Roles.FirstOrDefault())
                    .SetProperty(x => x.CurrentStatusDescriptionAr, x => newStatus.DescriptionAr)
                    .SetProperty(x => x.CurrentStatusDescriptionEn, x => newStatus.DescriptionEn)
                    .SetProperty(x => x.Data, x => JsonConvert.SerializeObject(kpi, new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    })));

        // await _requestRepository.UpdateAsync(request);

        await _unitOfWork.SaveChangesAsync();


        return new Result(NoContent);
    }


    private async Task<Kpi> handleKpiStatus(long? ExternalId, RequestStatus? newStatus, RequestStatus? oldStatus,
        long? reqeustId, string? comment)
    {
        var kpi = await _kpiRepository.GetAsync(ExternalId);

        var lookupValue = await _lookupValueRepository.Queryable
            .Where(x => x.Lookup.Code == "KpiStatus" ||
                        x.Lookup.Code == "MeasurementCycle").ToListAsync();

        switch (newStatus.Code)
        {
            case Constant.RejectedByStgAuditer:
            case Constant.RejectedByDepManager:
            case Constant.RejectedByStgManager:
                await handleRejectUpdateRequst(kpi, newStatus, lookupValue);
                break;
            case Constant.ApprovedByStgMnagaer:
                await handleApprovedKpi(kpi, lookupValue);
                // kpi.StatusId = lookupValue.Where(_ => _.Code.Trim().ToLower() == Constant.Approved.ToLower())
                //     ?.FirstOrDefault()?.Id;
                break;
        }

        await _mediator.Send(new AddWfTransactionRequest()
        {
            RequestId = reqeustId,
            Action = newStatus?.Code,
            Comment = comment,
            DepartmentCode = _currentUserService.DepartmentCode,
            RoleCode = _currentUserService.RoleCode,
            NewStatusCode = newStatus?.Code,
            NewStatusDescriptionAr = newStatus?.DescriptionAr,
            NewStatusDescriptionEn = newStatus?.DescriptionEn,
            OldStatusCode = oldStatus?.Code,
            OldStatusDescriptionAr = oldStatus?.DescriptionAr,
            OldStatusDescriptionEn = oldStatus?.DescriptionEn
        });

        await _kpiRepository.UpdateAsync(kpi);

        return kpi;
    }


    private async Task handleRejectUpdateRequst(Kpi kpi, RequestStatus? newStatus, List<LookupValue> lookupValue)
    {
        if (kpi.TypeId == (long)RequestTypeEnum.UpdateKPI
            && Constant.RejectStatusCode.Any(_ => _ == newStatus.Code))
        {
            var request =
                await _requestRepository.Queryable.Where(
                    x => x.ExternalId == kpi.Id && x.Type.Code == Constant.AddRequestType).FirstOrDefaultAsync();

            var oldkpi = JsonConvert.DeserializeObject<Kpi>(request.Data ,  new JsonSerializerSettings
            {
                ReferenceLoopHandling =  ReferenceLoopHandling.Ignore
            });

            kpi.Update(oldkpi.TypeId, oldkpi.MeasurementUnitId, oldkpi.MathematicalEquationAbId, oldkpi.NameAr,
                oldkpi.NameEn, oldkpi.DescriptionAr, oldkpi.DescriptionEn, oldkpi.MeasurementCycleId,
                oldkpi.DescriptionAAr, oldkpi.DescriptionAEn, oldkpi.DescriptionBAr, oldkpi.DescriptionBEn,
                oldkpi.IndicatorModularityId, oldkpi.IsPrivet, oldkpi.StatisticalIndicator,
                oldkpi.IndexCreationRateId, oldkpi.IndexSourceId, oldkpi.IndexClassId, oldkpi.BalancedScoredId,
                oldkpi.RelatedStratigicGoalId, oldkpi.FirstResultSourceId,
                oldkpi.FirstResult, oldkpi.FirstResultDetails, oldkpi.OwnerDepartemntId, oldkpi.OperationActionId,
                oldkpi.StartDate, oldkpi.EndDate, oldkpi.InputMethodId, oldkpi.AggregateCoefficientValuesMethodAId,
                oldkpi.AggregateCoefficientValuesMethodBId, oldkpi.KpiTypeId, oldkpi.PoliticsId, oldkpi.QualityOfLifeId, oldkpi.RiskId,
                oldkpi.SustainableDevelopmentGoalId , oldkpi.PolarityId, oldkpi.ParentKpiId);

            kpi.StatusId = lookupValue.Where(_ => _.Code.Trim().ToLower() == Constant.Approved.ToLower())
                ?.FirstOrDefault()?.Id;
        }
        else
            kpi.StatusId = lookupValue.Where(_ => _.Code.Trim().ToLower() == Constant.Rejected.ToLower())
                ?.FirstOrDefault()?.Id;
    }

    private async Task handleApprovedKpi(Kpi kpi, List<LookupValue> lookupValue)
    {
        kpi.StatusId = lookupValue.Where(_ => _.Code.Trim().ToLower() == Constant.Approved.ToLower())
            ?.FirstOrDefault()?.Id;


        var ExistingTask = await _kpiTaskRepository.Queryable.Where(_ => _.KpiId == kpi.Id).ToListAsync();

        if (ExistingTask.Any())
            ExistingTask.ForEach(async _ =>
            {
                _.IsDeleted = true;
                await _kpiTaskRepository.UpdateAsync(_);
            });

        string MeasurementCycleCode =
            lookupValue.Where(_ => _.Id == kpi.MeasurementCycleId).Select(_ => _.Code).FirstOrDefault();

        MeasurementCycleEnum MeasurementCycle =
            (MeasurementCycleEnum)Enum.Parse(typeof(MeasurementCycleEnum), MeasurementCycleCode);

        var records = GenerateKPITaskRecords(kpi.StartDate.Value, kpi.EndDate.Value, kpi.Id, MeasurementCycle);


        records.ForEach(async _ =>
        {
            await _kpiTaskRepository.AddAsync(_);
        });

    }


    public List<KpiTask> GenerateKPITaskRecords(DateTime startDate, DateTime endDate, long? kpiId,
        MeasurementCycleEnum MeasurementCycle)
    {
        var records = new List<KpiTask>();
        int intervalMonths = GetIntervalMonths(MeasurementCycle);
        //int totalMonths = GetMonthDifference(startDate, endDate);

        DateTime current = startDate;

         //int monthCounter = 1;

        DateTime? oldStartDate = null;
        DateTime? oldEndDate = null;

        while (current < endDate)
        {
            KpiTask task = new KpiTask();
            task.StartDate = !records.Any() ? startDate.AddMonths(intervalMonths - 1) : oldStartDate.Value.AddMonths(intervalMonths);
            task.EndDate = !records.Any() ? startDate.AddMonths(intervalMonths) : oldEndDate.Value.AddMonths(intervalMonths);
            task.KpiId = kpiId;
            task.VerificationRate = 0;
            task.AValue = 0;
            task.BValue = 0;
            task.Target = 0;

            oldStartDate = task.StartDate;
            oldEndDate = task.EndDate;



            records.Add(task);

            //monthCounter++;

            // Move to the next interval
            current = current.AddMonths(intervalMonths);
        }

        return records;
    }


    private int GetIntervalMonths(MeasurementCycleEnum MeasurementCycle)
    {
        return MeasurementCycle switch
        {
            MeasurementCycleEnum.Annual => 12,
            MeasurementCycleEnum.Biannual => 6,
            MeasurementCycleEnum.Quarterly => 3,
            MeasurementCycleEnum.Monthly => 1,
            _ => throw new ArgumentOutOfRangeException(nameof(MeasurementCycleEnum),
                $"Unhandled impact type: {MeasurementCycle}")
        };
    }


    // private int GetMonthDifference(DateTime startDate, DateTime endDate)
    // {
    //     return ((endDate.Year - startDate.Year) * 12) + endDate.Month - startDate.Month;
    // }
}
