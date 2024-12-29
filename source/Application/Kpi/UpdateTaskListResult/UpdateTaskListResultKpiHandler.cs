using AjKpi.Application.Common;
using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
using Newtonsoft.Json;
using Shared.Common;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdateTaskListResultKpiHandler : IRequestHandler<UpdateTaskListResultKpiRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    //private readonly IDepartmentRepository _departmentRepository;
    private readonly IRepositoryBase<KpiTask> _kpiTaskRepository;
    private readonly IRepositoryBase<Kpi> _kpiRepository;

    public UpdateTaskListResultKpiHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<KpiTask> kpiTaskRepository,
        IRepositoryBase<Kpi> kpiRepository
    )
    {
        _unitOfWork = unitOfWork;
        _kpiTaskRepository = kpiTaskRepository;
        _kpiRepository = kpiRepository;
    }

    public async Task<Result> Handle(UpdateTaskListResultKpiRequest request, CancellationToken cancellationToken)
    {

        long? kpiItemId = 0;
        foreach (var item in request.Items)
        {
            var kpiTask = await _kpiTaskRepository.GetAsync(item.Id);

            kpiItemId = kpiTask.KpiId;
            kpiTask.Calculate(item.AValue, item.BValue, item.ResultValue , item.VerificationRate , item.Target);

            kpiTask.Locked(item.IsLocked);

            await _kpiTaskRepository.UpdateAsync(kpiTask);
        }




        var kpi = await _kpiRepository.GetAsync(kpiItemId);

        kpi.SetResult(request.Result, request.Percent);

        await _kpiRepository.UpdateAsync(kpi);


        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
