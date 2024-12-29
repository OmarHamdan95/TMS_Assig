using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridLookupValueRequest : GridParameters , IRequest<Result<Grid<LookupValueModel>>>;
