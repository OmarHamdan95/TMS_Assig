namespace AjKpi.Application;

public sealed record DeleteRequest(long Id) : IRequest<Result>;
