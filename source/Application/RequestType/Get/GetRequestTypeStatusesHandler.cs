using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetRequestTypeStatusesHandler : IRequestHandler<GetRequestTypeStatusesRequest, Result<IEnumerable<ReqeustStatusModel>>>
{
    private readonly IWFRepositoryBase<RequestStatus> _requestStatusRepository;

    public GetRequestTypeStatusesHandler(IWFRepositoryBase<RequestStatus> requestStatusRepository) => _requestStatusRepository = requestStatusRepository;

    public async Task<Result<IEnumerable<ReqeustStatusModel>>> Handle(GetRequestTypeStatusesRequest request , CancellationToken cancellationToken)
    {
        var reqeusType = await _requestStatusRepository.ListAsyncByCodes<ReqeustStatusModel>(request.Codes);

        return new Result<IEnumerable<ReqeustStatusModel>>(reqeusType is null ? NotFound : OK, reqeusType);
    }
}
