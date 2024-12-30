namespace TMS.Application;

public sealed record DeleteLookupValueRequest(long Id) : IRequest<Result>;
