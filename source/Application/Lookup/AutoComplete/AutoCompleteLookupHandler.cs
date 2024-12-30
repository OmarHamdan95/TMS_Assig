using Microsoft.EntityFrameworkCore;
using Shared.Common;
using TMS.Application.Common;
using TMS.Database;
using TMS.Domain;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Extensions = DotNetCore.Security.Extensions;

namespace TMS.Application;

public sealed record
    AutoCompleteLookupHandler : IRequestHandler<AutoCompleteLookupRequest, Result<IEnumerable<LookupValueModel>>>
{
    private readonly ILookupValueRepository _lookupRepository;
    private readonly ICurrentUserService _currentUserService;

    public AutoCompleteLookupHandler(ILookupValueRepository lookupRepository,
        ICurrentUserService currentUserService) =>
        (_lookupRepository, _currentUserService) =
        (lookupRepository, currentUserService);


    public async Task<Result<IEnumerable<LookupValueModel>>> Handle(AutoCompleteLookupRequest request,
        CancellationToken cancellationToken)
    {
        IEnumerable<LookupValueModel> lookup = null;


        lookup = await _lookupRepository.AutoComplate<LookupValueModel>(request.lookupCode, request.text);

        return new Result<IEnumerable<LookupValueModel>>(lookup is null ? NotFound : OK, lookup);
    }
}
