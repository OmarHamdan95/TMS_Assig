using AjKpi.Model;

namespace AjKpi.Application;

public sealed record AutoCompleteLookupRequest(string? lookupCode , long? parentId ,  string? text) : IRequest<Result<IEnumerable<LookupValueModel>>>;
