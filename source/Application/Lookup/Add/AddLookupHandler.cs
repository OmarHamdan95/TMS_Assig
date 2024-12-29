using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;

namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record AddLookupHandler : IRequestHandler<AddLookupRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Lookup> _lookupRepository;

    public AddLookupHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Lookup> lookupRepository
    )
    {
        _unitOfWork = unitOfWork;
        _lookupRepository = lookupRepository;
    }

    public async Task<Result<long>> Handle(AddLookupRequest request, CancellationToken cancellationToken)
    {
        var lookup = new Lookup(request.Code,
            request.NameAr,
            request.NameEn,
           //request.TranslationModel.Adapt<LocalizedText>(),
            request.dataType,
            request.parent?.Id ?? null);

        await _lookupRepository.AddAsync(lookup);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, lookup.Id);
        // throw new NotImplementedException();
    }
}
