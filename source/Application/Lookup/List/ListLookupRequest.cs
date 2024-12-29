using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListLookupRequest : IRequest<Result<IEnumerable<LookupModel>>>;
