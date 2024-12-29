using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridLookupRequest : GridParameters , IRequest<Result<Grid<LookupModel>>>;
