using TMS.Database;
using TMS.Domain;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record InactivateLookupValueHandler : IRequestHandler<InactivateLookupValueRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILookupValueRepository _lookupValueRepository;

    public InactivateLookupValueHandler
    (
        IUnitOfWork unitOfWork,
        ILookupValueRepository lookupValueRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupValueRepository = lookupValueRepository;
    }

    public async Task<Result> Handle(InactivateLookupValueRequest request , CancellationToken cancellationToken)
    {
        var lookup = new LookupValue(request.Id);

       // lookup.Inactivate();

        await _lookupValueRepository.UpdatePartialAsync(new { lookup.Id, lookup.ValidTo });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
