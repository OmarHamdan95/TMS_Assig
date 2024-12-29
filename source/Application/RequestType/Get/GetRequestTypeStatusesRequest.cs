using AjKpi.Model;

namespace AjKpi.Application;

public record GetRequestTypeStatusesRequest(string? Codes = null) :  IRequest<Result<IEnumerable<ReqeustStatusModel>>>;
