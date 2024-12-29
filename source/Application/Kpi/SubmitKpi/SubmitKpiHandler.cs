using AjKpi.Application.Common;
using Newtonsoft.Json;
using Shared.Common;

namespace AjKpi.Application;

using static System.Net.HttpStatusCode;


public class SubmitKpiHandler :  IRequestHandler<SubmitKpiReqeust, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Kpi> _kpiRepository;
    private readonly IMediator _mediator;
    private readonly ICurrentUserService _currentUserService;
    private readonly IWFRepositoryBase<RequestStatus> _reqeuestStatusRepo;

    public SubmitKpiHandler(IUnitOfWork unitOfWork, IRepositoryBase<Kpi> kpiRepository , IMediator mediator
        , ICurrentUserService currentUserService , IWFRepositoryBase<RequestStatus> reqeuestStatusRepo) =>
        (_unitOfWork, _kpiRepository , _mediator , _currentUserService , _reqeuestStatusRepo) = (unitOfWork, kpiRepository ,mediator , currentUserService , reqeuestStatusRepo);


    public async Task<Result> Handle(SubmitKpiReqeust request, CancellationToken cancellationToken)
    {
        var record = await _kpiRepository.GetAsync(request.KpiId);

        record.UpdateStats((long)KpiStatusEnum.InProgress);

        try
        {
            RequestModel requestModel = new RequestModel()
            {
                Status = "SUBMIT",
                Data = JsonConvert.SerializeObject(record ,  new JsonSerializerSettings
                {
                    ReferenceLoopHandling =  ReferenceLoopHandling.Ignore
                }),
                Type = "ADD_NEW_KPI",
                ExternalId = record.Id ,
                InitDepartmentCode = _currentUserService.DepartmentCode ,
                TargetDepartmentCode = _currentUserService.DepartmentCode,
                TargetRoleCode = _reqeuestStatusRepo.Queryable.Where(x=> x.Code == "SUBMIT").FirstOrDefault().Roles.FirstOrDefault()
            };

            var result = await _mediator.Send(new AddRequest(requestModel));

            record.SetNumber(result.Value.Number);
            record.SetReqeust(result.Value.Id);

            await _mediator.Send(new AddWfTransactionRequest()
            {
                RequestId = result.Value.Id,
                Action = "SUBMIT"
            });

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }

        await _kpiRepository.UpdateAsync(record);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long?>(NoContent);
    }



}
