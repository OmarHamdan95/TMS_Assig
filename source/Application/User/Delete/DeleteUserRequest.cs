namespace AjKpi.Application;

public sealed record DeleteUserRequest(long Id) : IRequest<Result>;
