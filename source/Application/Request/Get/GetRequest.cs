using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetRequest(long Id) : IRequest<Result<RequestGridModel>>;
