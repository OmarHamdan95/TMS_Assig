using AjKpi.Application.Common;
using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
using Newtonsoft.Json;
using Shared.Common;

namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record AddKpitHandler : IRequestHandler<AddKpiRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly IMediator _mediator;
    private readonly ICurrentUserService _currentUserService;
    private readonly IWFRepositoryBase<RequestStatus> _reqeuestStatusRepo;

    public AddKpitHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Kpi> kpiRepository,
        ICurrentUserService currentUserService,
        IMediator mediator,
        IWFRepositoryBase<RequestStatus> reqeuestStatusRepo
        //
    )
    {
        _unitOfWork = unitOfWork;
        _kpiRepository = kpiRepository;
        _mediator = mediator;
        _currentUserService = currentUserService;
        _reqeuestStatusRepo = reqeuestStatusRepo;
    }

    public async Task<Result<long>> Handle(AddKpiRequest request, CancellationToken cancellationToken)
    {

        //add init values
        request.Code = "sec-1234-2-024";
        request.TypeId = (long)RequestTypeEnum.CreateKPI;
        //request.StatusId = (long)KpiStatusEnum.Submit;
        string departmentIdString = _currentUserService?.DepartmentId; // Assuming this is a string
        long departmentId = 0; // Default value in case conversion fails
        long.TryParse(departmentIdString, out departmentId);


        if (request.DepartmentId.HasValue)
            departmentId = request.DepartmentId.Value;


        var kpi = new Kpi(request.Code, request.Number, request.TypeId, request.KpiTypeId, request.MeasurementUnitId, request.MathematicalEquationAbId,
            request.NameAr, request.NameEn,
            request.DescriptionAr, request.DescriptionEn, request.MeasurementCycleId, request.DescriptionAAr, request.DescriptionAEn,
            request.DescriptionBAr, request.DescriptionBEn,
            request.IndicatorModularityId, request.IsPrivet, request.StatisticalIndicator, request.IndexCreationRateId,
            request.IndexSourceId, request.IndexClassId,
            request.BalancedScoredId, request.RelatedStratigicGoalId, request.FirstResultSourceId, request.FirstResult,
            request.FirstResultDetails, departmentId, request.OperationActionId,
            request.StatusId, request.StartDate, request.EndDate, request.InputMethodId, request.AggregateCoefficientValuesMethodAId,
            request.AggregateCoefficientValuesMethodBId, request.PoliticsId, request.QualityOfLifeId, request.RiskId, request.SustainableDevelopmentGoalsId, request.PolarityId, request.ParentKpiId);

        //kpi.StatusId = null;


        await _kpiRepository.AddAsync(kpi);

        await _unitOfWork.SaveChangesAsync();

        if (request.StatusId == (long)KpiStatusEnum.Submit)
        {
            try
            {

                RequestModel requestModel = new RequestModel()
                {
                    Status = "SUBMIT",
                    Data = JsonConvert.SerializeObject(kpi,  new JsonSerializerSettings
                    {
                        ReferenceLoopHandling =  ReferenceLoopHandling.Ignore
                    }),
                    Type = "ADD_NEW_KPI",
                    ExternalId = kpi.Id,
                    InitDepartmentCode = _currentUserService.DepartmentCode,
                    TargetDepartmentCode = _currentUserService.DepartmentCode,
                    TargetRoleCode = _reqeuestStatusRepo.Queryable.Where(x => x.Code == "SUBMIT").FirstOrDefault().Roles.FirstOrDefault()

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

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            await _kpiRepository.UpdateAsync(kpi);

        }

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, kpi.Id);
    }
}
