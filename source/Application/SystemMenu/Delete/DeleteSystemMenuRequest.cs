namespace AjKpi.Application;

public sealed record DeleteSystemMenuRequest(long Id) : IRequest<Result>;
