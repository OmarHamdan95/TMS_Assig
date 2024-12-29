using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record InactivateLookupHandler : IRequestHandler<InactivateLookupRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Lookup> _lookupRepository;

    public InactivateLookupHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Lookup> lookupRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupRepository = lookupRepository;
    }

    public async Task<Result> Handle(InactivateLookupRequest request , CancellationToken cancellationToken)
    {
        var lookup = new Lookup(request.Id);

        lookup.Inactivate();

        await _lookupRepository.UpdatePartialAsync(new { lookup.Id, lookup.ValidTo });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
