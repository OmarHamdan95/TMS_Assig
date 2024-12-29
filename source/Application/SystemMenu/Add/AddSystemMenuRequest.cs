using AjKpi.Model;

namespace AjKpi.Application;

public sealed record AddSystemMenuRequest(string? Name,
    string? Icon,
    string? Route,
    string? Permission,
    SystemMenuModel? Parent,
    string? ModuleCode,
    List<SystemMenuModel>? Child) : IRequest<Result<long>>;
