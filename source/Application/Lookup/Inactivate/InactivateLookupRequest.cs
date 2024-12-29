namespace AjKpi.Application;

public sealed record InactivateLookupRequest(long Id) : IRequest<Result>;
