using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetRequestTypesHandler : IRequestHandler<GetRequestTypesRequest, Result<IEnumerable<RequestTypeModel>>>
{
    private readonly IWFRepositoryBase<RequestType> _requestTypeRepository;

    public GetRequestTypesHandler(IWFRepositoryBase<RequestType> requestTypeRepository) => _requestTypeRepository = requestTypeRepository;

    public async Task<Result<IEnumerable<RequestTypeModel>>> Handle(GetRequestTypesRequest request , CancellationToken cancellationToken)
    {
        var reqeusType = await _requestTypeRepository.ListAsyncByCodes<RequestTypeModel>(request.Codes);

        return new Result<IEnumerable<RequestTypeModel>>(reqeusType is null ? NotFound : OK, reqeusType);
    }
}
