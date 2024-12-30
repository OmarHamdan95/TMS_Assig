namespace TMS.Application;

public sealed record DeleteTaskRequest(long Id) : IRequest<Result>;
