using TMS.Model;

namespace TMS.Application;

public sealed record GridLookupValueRequest : GridParameters , IRequest<Result<Grid<LookupValueModel>>>;
