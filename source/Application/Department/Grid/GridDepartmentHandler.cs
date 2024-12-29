using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridDepartmentHandler : IRequestHandler<GridDepartmentRequest, Result<Grid<DepartmentModel>>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GridDepartmentHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

    public async Task<Result<Grid<DepartmentModel>>> Handle(GridDepartmentRequest request , CancellationToken cancellationToken)
    {
        var grid = await _departmentRepository.GridAsync<DepartmentModel>(request);

        return new Result<Grid<DepartmentModel>>(grid is null ? NotFound : OK, grid);
    }

}
