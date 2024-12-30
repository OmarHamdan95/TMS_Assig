using TMS.Model;

namespace TMS.Application;

public sealed record ListLookupRequest : IRequest<Result<IEnumerable<LookupModel>>>;
