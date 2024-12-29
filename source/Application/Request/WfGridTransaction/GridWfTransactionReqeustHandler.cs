using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridWfTransactionReqeustHandler : IRequestHandler<GridWfTransactionReqeust, Result<Grid<WfTransactionModel>>>
{
    private readonly IWFRepositoryBase<WfTransaction> _wfTransactionRepository;

    public GridWfTransactionReqeustHandler(IWFRepositoryBase<WfTransaction> wfTransactionRepository) => _wfTransactionRepository = wfTransactionRepository;

    public async Task<Result<Grid<WfTransactionModel>>> Handle(GridWfTransactionReqeust request , CancellationToken cancellationToken)
    {
        var result = await _wfTransactionRepository.GridAsync<WfTransactionModel>(request);

        return new Result<Grid<WfTransactionModel>>(result is null ? NotFound : OK, result);
    }

}
