using TMS.Domain;
using TMS.Database;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record DeleteLookupValueHandler : IRequestHandler<DeleteLookupValueRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILookupValueRepository _lookupValueRepository;

    public DeleteLookupValueHandler
    (
        IUnitOfWork unitOfWork,
        ILookupValueRepository lookupValueRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupValueRepository = lookupValueRepository;
    }

    public async Task<Result> Handle(DeleteLookupValueRequest request , CancellationToken cancellationToken)
    {

        await _lookupValueRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
