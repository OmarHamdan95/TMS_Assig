
namespace AjKpi.Application;

public sealed record AddRequest (RequestModel request) : IRequest<Result<RequestResult>>;
