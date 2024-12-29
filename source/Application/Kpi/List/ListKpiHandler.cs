using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListKpiHandler : IRequestHandler<ListKpiRequest, Result<IEnumerable<KpiModel>>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;

    public ListKpiHandler(IRepositoryBase<Kpi> kpiRepository) => _kpiRepository = kpiRepository;

    public async Task<Result<IEnumerable<KpiModel>>> Handle(ListKpiRequest request , CancellationToken cancellationToken)
    {
        var lookups = await _kpiRepository.ListModelAsync<KpiModel>();

        return new Result<IEnumerable<KpiModel>>(lookups is null ? NotFound : OK, lookups);
    }
}
