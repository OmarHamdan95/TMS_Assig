using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetLookupRequest(long Id) : IRequest<Result<LookupModel>>;
