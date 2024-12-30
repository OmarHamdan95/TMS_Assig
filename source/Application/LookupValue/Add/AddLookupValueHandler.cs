using TMS.Domain.Common;
using Mapster;
using TMS.Database;
using TMS.Domain;

namespace TMS.Application;

using static System.Net.HttpStatusCode;

public sealed record AddLookupValueHandler : IRequestHandler<AddLookupValueRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILookupValueRepository _lookupValueRepository;

    public AddLookupValueHandler
    (
        IUnitOfWork unitOfWork,
        ILookupValueRepository LookupValueRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupValueRepository = LookupValueRepository;
    }

    public async Task<Result<long>> Handle(AddLookupValueRequest request, CancellationToken cancellationToken)
    {
        var lookupValue = new LookupValue(request.Code,
            null,
            null,
            request.NameAr,
            request.NameEn,
            request.parent?.Id ?? null,
            request.LookupId
            );



        await _lookupValueRepository.AddAsync(lookupValue);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, lookupValue.Id);
        // throw new NotImplementedException();
    }
}
