using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListDepartmentHandler : IRequestHandler<ListDepartmentRequest, Result<IEnumerable<DepartmentModel>>>
{
    private readonly IDepartmentRepository _departmentRepository;

    public ListDepartmentHandler(IDepartmentRepository departmentRepository) => _departmentRepository = departmentRepository;

    public async Task<Result<IEnumerable<DepartmentModel>>> Handle(ListDepartmentRequest request , CancellationToken cancellationToken)
    {
        var lookups = await _departmentRepository.ListModelAsync<DepartmentModel>();

        return new Result<IEnumerable<DepartmentModel>>(lookups is null ? NotFound : OK, lookups);
    }
}
