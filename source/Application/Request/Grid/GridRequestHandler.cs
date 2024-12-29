using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridRequestHandler : IRequestHandler<GridRequest, Result<Grid<RequestGridModel>>>
{
    private readonly IRepositoryBase<Request> _reqeustRepository;

    public GridRequestHandler(IRepositoryBase<Request> reqeustRepository) => _reqeustRepository = reqeustRepository;

    public async Task<Result<Grid<RequestGridModel>>> Handle(GridRequest request , CancellationToken cancellationToken)
    {
        var grid = await _reqeustRepository.GridAsync<RequestGridModel>(request);

        return new Result<Grid<RequestGridModel>>(grid is null ? NotFound : OK, grid);
    }

}
