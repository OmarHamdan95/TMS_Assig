namespace AjKpi.Application;

public sealed record InactivateLookupValueRequest(long Id) : IRequest<Result>;
