using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetKpiHandler : IRequestHandler<GetKpiRequest, Result<KpiResultModel>>
{
    private readonly IRepositoryBase<Kpi> _kpiRepository;

    public GetKpiHandler(IRepositoryBase<Kpi> kpiRepository) => _kpiRepository = kpiRepository;

    public async Task<Result<KpiResultModel>> Handle(GetKpiRequest request , CancellationToken cancellationToken)
    {
        var kpi = await _kpiRepository.GetModelAsync<KpiResultModel>(request.Id);

        return new Result<KpiResultModel>(kpi is null ? NotFound : OK, kpi);
    }
}
