using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetSystemMenuRequest(long Id) : IRequest<Result<SystemMenuModel>>;
