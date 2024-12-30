using TMS.Database;
using TMS.Domain;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record DeleteLookupHandler : IRequestHandler<DeleteLookupRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Lookup> _lookupRepository;

    public DeleteLookupHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Lookup> lookupRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupRepository = lookupRepository;
    }

    public async Task<Result> Handle(DeleteLookupRequest request , CancellationToken cancellationToken)
    {

        await _lookupRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
