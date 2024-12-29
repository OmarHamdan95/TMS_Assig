using AjKpi.Model;

namespace AjKpi.Application;

public record GetRequestTypesRequest(string? Codes = null) :  IRequest<Result<IEnumerable<RequestTypeModel>>>;
