using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListRequestHandler : IRequestHandler<ListRequest, Result<IEnumerable<RequestModel>>>
{
    private readonly IRepositoryBase<Request> _requestRepository;

    public ListRequestHandler(IRepositoryBase<Request> requestRepository) => _requestRepository = requestRepository;

    public async Task<Result<IEnumerable<RequestModel>>> Handle(ListRequest request , CancellationToken cancellationToken)
    {
        var requestData = await _requestRepository.ListModelAsync<RequestModel>();

        return new Result<IEnumerable<RequestModel>>(requestData is null ? NotFound : OK, requestData);
    }
}
