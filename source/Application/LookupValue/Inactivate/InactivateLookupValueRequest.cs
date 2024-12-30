namespace TMS.Application;

public sealed record InactivateLookupValueRequest(long Id) : IRequest<Result>;
