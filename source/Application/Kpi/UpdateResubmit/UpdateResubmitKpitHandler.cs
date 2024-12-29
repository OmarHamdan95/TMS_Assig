using AjKpi.Application.Common;
using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
using Newtonsoft.Json;
using Shared.Common;

namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record UpdateResubmitRequestKpitHandler : IRequestHandler<UpdateResubmitKpiRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly IMediator _mediator;
    private readonly ICurrentUserService _currentUserService;
    private readonly IWFRepositoryBase<RequestStatus> _reqeuestStatusRepo;

    public UpdateResubmitRequestKpitHandler
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

    public async Task<Result<long>> Handle(UpdateResubmitKpiRequest request, CancellationToken cancellationToken)
    {
        if (request.Item != null)
        {
            var kpi = await _kpiRepository.GetAsync(request.Item.Id);

            if (kpi is null) return new Result<long>(NotFound);

            kpi.Update(request.Item.TypeId,request.Item.MeasurementUnitId, request.Item.MathematicalEquationAbId,request.Item.NameAr,request.Item.NameEn,
                request.Item.DescriptionAr, request.Item.DescriptionEn,request.Item.MeasurementCycleId, request.Item.DescriptionAAr,
                request.Item.DescriptionAEn, request.Item.DescriptionBAr,request.Item.DescriptionBEn,request.Item.IndicatorModularityId,request.Item.IsPrivet,
                request.Item.StatisticalIndicator,request.Item.IndexCreationRateId,request.Item.IndexSourceId,request.Item.IndexClassId,
                request.Item.BalancedScoredId, request.Item.RelatedStratigicGoalId,request.Item.FirstResultSourceId,
                request.Item.FirstResult,request.Item.FirstResultDetails,kpi.OwnerDepartemntId,request.Item.OperationActionId,
                request.Item.StartDate, request.Item.EndDate, request.Item.InputMethodId,request.Item.AggregateCoefficientValuesMethodAId,
                request.Item.AggregateCoefficientValuesMethodBId, request.Item.KpiTypeId, request.Item.PoliticsId, request.Item.QualityOfLifeId,
                request.Item.RiskId, request.Item.SustainableDevelopmentGoalId, request.Item.PolarityId,request.Item.ParentKpiId);

            await _kpiRepository.UpdateAsync(kpi);


            await _mediator.Send(new UpdateRequestStatus(kpi.RequestId, request.Action.Status, request.Action.Note));


            await _unitOfWork.SaveChangesAsync();
            //add init values


            return new Result<long>(NoContent, kpi.Id);
        }

        throw new Exception("Something error please contact admin");
    }
}
