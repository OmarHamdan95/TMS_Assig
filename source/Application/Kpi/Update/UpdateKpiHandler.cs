using AjKpi.Application.Common;
using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
using Newtonsoft.Json;
using Shared.Common;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdateKpiHandler : IRequestHandler<UpdateKpiRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    //private readonly IDepartmentRepository _departmentRepository;
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IMediator _mediator;
    private readonly IWFRepositoryBase<RequestStatus> _reqeuestStatusRepo;

    public UpdateKpiHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Kpi> kpiRepository,
        ICurrentUserService currentUserService,
        IMediator mediator,
        IWFRepositoryBase<RequestStatus> reqeuestStatusRepo
    )
    {
        _unitOfWork = unitOfWork;
        _kpiRepository = kpiRepository;
        _currentUserService = currentUserService;
        _mediator = mediator;
        _reqeuestStatusRepo = reqeuestStatusRepo;
    }

    public async Task<Result> Handle(UpdateKpiRequest request, CancellationToken cancellationToken)
    {
        var kpi = await _kpiRepository.GetAsync(request.Id);

        if (kpi is null) return new Result(NotFound);

        //result.Update(request.);
        kpi.Update((long)RequestTypeEnum.UpdateKPI, request.MeasurementUnitId, request.MathematicalEquationAbId, request.NameAr,
            request.NameEn,
            request.DescriptionAr, request.DescriptionEn, request.MeasurementCycleId, request.DescriptionAAr,
            request.DescriptionAEn, request.DescriptionBAr, request.DescriptionBEn, request.IndicatorModularityId,
            request.IsPrivet,
            request.StatisticalIndicator, request.IndexCreationRateId, request.IndexSourceId, request.IndexClassId,
            request.BalancedScoredId, request.RelatedStratigicGoalId, request.FirstResultSourceId,
            request.FirstResult, request.FirstResultDetails, kpi.OwnerDepartemntId, request.OperationActionId,
            request.StartDate, request.EndDate, request.InputMethodId, request.AggregateCoefficientValuesMethodAId,
            request.AggregateCoefficientValuesMethodBId, request.KpiTypeId,
            request.PoliticsId , request.QualityOfLifeId, request.RiskId, request.SustainableDevelopmentGoalId, request.PolarityId, request.ParentKpiId);


        await _kpiRepository.UpdateAsync(kpi);


        RequestModel requestModel = new RequestModel()
        {
            Status = "SUBMIT",
            Data = JsonConvert.SerializeObject(kpi ,  new JsonSerializerSettings
            {
                ReferenceLoopHandling =  ReferenceLoopHandling.Ignore
            } ),
            Type = "UPDATE_KPI",
            ExternalId = kpi.Id,
            InitDepartmentCode = _currentUserService.DepartmentCode,
            TargetDepartmentCode = _currentUserService.DepartmentCode,
            TargetRoleCode = _reqeuestStatusRepo.Queryable.Where(x => x.Code == "SUBMIT").FirstOrDefault().Roles
                .FirstOrDefault()
        };

        var result = await _mediator.Send(new AddRequest(requestModel));

        kpi.SetNumber(result.Value.Number);
        kpi.SetReqeust(result.Value.Id);
        kpi.UpdateStats((long)KpiStatusEnum.InProgress);

        await _mediator.Send(new AddWfTransactionRequest()
        {
            RequestId = result.Value.Id,
            Action = "SUBMIT",
            Comment = request.InitiaterNotes,
            OldStatusDescriptionAr = "تحرير",
            OldStatusDescriptionEn = "Submit",
            NewStatusDescriptionAr = "بانتظار موافقة مدير القسم",
            NewStatusDescriptionEn = "Waiting Head Of Department Approval",
        });

        // Call Audit Service (Old Value , New Value);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
