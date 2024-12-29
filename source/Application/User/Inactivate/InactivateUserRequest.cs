namespace AjKpi.Application;

public sealed record InactivateUserRequest(long Id) : IRequest<Result>;
