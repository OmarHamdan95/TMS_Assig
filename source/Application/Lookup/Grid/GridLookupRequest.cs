using TMS.Model;

namespace TMS.Application;

public sealed record GridLookupRequest : GridParameters , IRequest<Result<Grid<LookupModel>>>;
