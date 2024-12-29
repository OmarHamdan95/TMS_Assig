using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridDepartmentRequest : GridParameters , IRequest<Result<Grid<DepartmentModel>>>;
