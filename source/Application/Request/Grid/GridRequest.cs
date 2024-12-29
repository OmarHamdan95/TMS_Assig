using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridRequest : GridParameters , IRequest<Result<Grid<RequestGridModel>>>;
