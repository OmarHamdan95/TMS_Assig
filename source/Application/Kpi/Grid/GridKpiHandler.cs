using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridKpiHandler : IRequestHandler<GridKpiRequest, Result<Grid<KpiGridModel>>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;

    public GridKpiHandler(IRepositoryBase<Kpi> kpiRepository) => _kpiRepository = kpiRepository;

    public async Task<Result<Grid<KpiGridModel>>> Handle(GridKpiRequest request , CancellationToken cancellationToken)
    {
        var grid = await _kpiRepository.GridAsync<KpiGridModel>(request);

        return new Result<Grid<KpiGridModel>>(grid is null ? NotFound : OK, grid);
    }

}
