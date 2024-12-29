using AjKpi.Application.Common;
using Microsoft.IdentityModel.Tokens;
using static System.Net.HttpStatusCode;
using Shared.Common;
using Microsoft.EntityFrameworkCore;

namespace AjKpi.Application;

public sealed record GridKpiTaskListResultHandler : IRequestHandler<GridKpiTaskListResultRequest, Result<Grid<KpiTaskListResult>>>
{
    private readonly IRepositoryBase<KpiTask> _kpiTaskRepository;
    private readonly ICurrentUserService _currentUserService;
    private readonly IRepositoryBase<Department> _departmentRepository;

    public GridKpiTaskListResultHandler(IRepositoryBase<KpiTask> kpiTaskRepository, ICurrentUserService currentUserService, IRepositoryBase<Department> departmentRepository) =>
        (_kpiTaskRepository, _currentUserService, _departmentRepository) = (kpiTaskRepository, currentUserService, departmentRepository);

    public async Task<Result<Grid<KpiTaskListResult>>> Handle(GridKpiTaskListResultRequest request , CancellationToken cancellationToken)
    {
        var grid = await _kpiTaskRepository.GridAsync<KpiTaskListResult>(request);

        return new Result<Grid<KpiTaskListResult>>(grid is null ? NotFound : OK, grid);
    }

}
