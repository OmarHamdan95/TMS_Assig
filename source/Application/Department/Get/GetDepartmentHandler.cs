using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetDepartmentHandler : IRequestHandler<GetDepartmentRequest, Result<DepartmentModel>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public GetDepartmentHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

    public async Task<Result<DepartmentModel>> Handle(GetDepartmentRequest request , CancellationToken cancellationToken)
    {
        var Department = await _departmentRepository.GetModelAsync<DepartmentModel>(request.Id);

        return new Result<DepartmentModel>(Department is null ? NotFound : OK, Department);
    }
}
