using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListDepartmentRequest : IRequest<Result<IEnumerable<DepartmentModel>>>;
