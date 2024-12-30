using TMS.Domain;
using TMS.Domain.Common;
using Mapster;
using TMS.Database;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record UpdateLookupValueHandler : IRequestHandler<UpdateLookupValueRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILookupValueRepository _lookupValueRepository;

    public UpdateLookupValueHandler
    (
        IUnitOfWork unitOfWork,
        ILookupValueRepository lookupValueRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupValueRepository = lookupValueRepository;
    }

    public async Task<Result> Handle(UpdateLookupValueRequest request , CancellationToken cancellationToken)
    {
        var lookup = await _lookupValueRepository.GetAsync(request.Id);

        if (lookup is null) return new Result(NotFound);

        lookup.UpdateLookupValue(request.NameAr, request.NameEn);

        await _lookupValueRepository.UpdateAsync(lookup);

        // Call Audit Service (Old Value , New Value);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
