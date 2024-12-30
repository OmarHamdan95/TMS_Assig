using TMS.Model;

namespace TMS.Application;

public sealed record GetLookupRequest(long Id) : IRequest<Result<LookupModel>>;
