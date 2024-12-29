using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListLookupValueHandler : IRequestHandler<ListLookupValueRequest, Result<IEnumerable<LookupValueModel>>>
{
    private readonly ILookupValueRepository _lookupValueRepository;

    public ListLookupValueHandler(ILookupValueRepository lookupValueRepository) => _lookupValueRepository = lookupValueRepository;

    public async Task<Result<IEnumerable<LookupValueModel>>> Handle(ListLookupValueRequest request , CancellationToken cancellationToken)
    {
        var lookups = await _lookupValueRepository.ListModelAsync<LookupValueModel>();

        return new Result<IEnumerable<LookupValueModel>>(lookups is null ? NotFound : OK, lookups);
    }
}
