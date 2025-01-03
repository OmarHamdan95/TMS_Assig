using TMS.Database;
using TMS.Domain;
using TMS.Model;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record GetLookupHandler : IRequestHandler<GetLookupRequest, Result<LookupModel>>
{
    private readonly IRepositoryBase<Lookup> _lookupRepository;

    public GetLookupHandler(IRepositoryBase<Lookup> lookupRepository) => _lookupRepository = lookupRepository;

    public async Task<Result<LookupModel>> Handle(GetLookupRequest request , CancellationToken cancellationToken)
    {
        var lookup = await _lookupRepository.GetModelAsync<LookupModel>(request.Id);

        return new Result<LookupModel>(lookup is null ? NotFound : OK, lookup);
    }
}
