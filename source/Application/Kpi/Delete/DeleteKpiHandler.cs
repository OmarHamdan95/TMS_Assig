using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeleteKpiHandler : IRequestHandler<DeleteKpiRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Kpi> _kpiRepository;

    public DeleteKpiHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Kpi> kpiRepository
    )
    {
        _unitOfWork = unitOfWork;
        _kpiRepository = kpiRepository;
    }

    public async Task<Result> Handle(DeleteKpiRequest request , CancellationToken cancellationToken)
    {

        await _kpiRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
