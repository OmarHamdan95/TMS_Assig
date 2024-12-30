using TMS.Domain;
using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record GetLookupValueHandler : IRequestHandler<GetLookupValueRequest, Result<LookupValueModel>>
{
    private readonly ILookupValueRepository _lookupValueRepository;

    public GetLookupValueHandler(ILookupValueRepository lookupValueRepository) => _lookupValueRepository = lookupValueRepository;

    public async Task<Result<LookupValueModel>> Handle(GetLookupValueRequest request , CancellationToken cancellationToken)
    {
        var lookup = await _lookupValueRepository.GetModelAsync<LookupValueModel>(request.Id);

        return new Result<LookupValueModel>(lookup is null ? NotFound : OK, lookup);
    }
}
