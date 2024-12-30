using TMS.Database;
using TMS.Domain;
using TMS.Model;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record ListLookupHandler : IRequestHandler<ListLookupRequest, Result<IEnumerable<LookupModel>>>
{
    private readonly IRepositoryBase<Lookup> _lookupRepository;

    public ListLookupHandler(IRepositoryBase<Lookup> lookupRepository) => _lookupRepository = lookupRepository;

    public async Task<Result<IEnumerable<LookupModel>>> Handle(ListLookupRequest request , CancellationToken cancellationToken)
    {
        var lookups = await _lookupRepository.ListModelAsync<LookupModel>();

        return new Result<IEnumerable<LookupModel>>(lookups is null ? NotFound : OK, lookups);
    }
}
