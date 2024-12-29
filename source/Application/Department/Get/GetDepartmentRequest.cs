using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetDepartmentRequest(long Id) : IRequest<Result<DepartmentModel>>;
