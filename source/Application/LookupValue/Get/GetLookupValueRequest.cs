using TMS.Model;

namespace TMS.Application;

public sealed record GetLookupValueRequest(long Id) : IRequest<Result<LookupValueModel>>;
