using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListRequest : IRequest<Result<IEnumerable<RequestModel>>>;
