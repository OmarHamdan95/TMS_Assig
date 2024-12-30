using TMS.Domain;
using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record GridLookupValueHandler : IRequestHandler<GridLookupValueRequest, Result<Grid<LookupValueModel>>>
{
    private readonly ILookupValueRepository _lookupValueRepository;

    public GridLookupValueHandler(ILookupValueRepository lookupValueRepository) => _lookupValueRepository = lookupValueRepository;

    public async Task<Result<Grid<LookupValueModel>>> Handle(GridLookupValueRequest request , CancellationToken cancellationToken)
    {
        var grid = await _lookupValueRepository.GridAsync<LookupValueModel>(request);

        return new Result<Grid<LookupValueModel>>(grid is null ? NotFound : OK, grid);
    }

}
