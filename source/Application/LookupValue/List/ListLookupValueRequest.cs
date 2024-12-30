using TMS.Model;

namespace TMS.Application;

public sealed record ListLookupValueRequest : IRequest<Result<IEnumerable<LookupValueModel>>>;
