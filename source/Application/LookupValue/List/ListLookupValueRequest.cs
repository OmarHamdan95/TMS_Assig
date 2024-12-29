using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListLookupValueRequest : IRequest<Result<IEnumerable<LookupValueModel>>>;
