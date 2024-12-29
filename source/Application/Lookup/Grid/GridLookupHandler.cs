using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridLookupHandler : IRequestHandler<GridLookupRequest, Result<Grid<LookupModel>>>
{
    private readonly IRepositoryBase<Lookup> _lookupRepository;

    public GridLookupHandler(IRepositoryBase<Lookup> lookupRepository) => _lookupRepository = lookupRepository;

    public async Task<Result<Grid<LookupModel>>> Handle(GridLookupRequest request , CancellationToken cancellationToken)
    {
        var grid = await _lookupRepository.GridAsync<LookupModel>(request);

        return new Result<Grid<LookupModel>>(grid is null ? NotFound : OK, grid);
    }

}
