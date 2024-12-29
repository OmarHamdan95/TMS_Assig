using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListSystemMenuRequest(string ModuleCode) : IRequest<Result<IEnumerable<SystemMenuModel>>>;
