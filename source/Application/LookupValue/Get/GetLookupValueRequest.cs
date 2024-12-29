using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetLookupValueRequest(long Id) : IRequest<Result<LookupValueModel>>;
