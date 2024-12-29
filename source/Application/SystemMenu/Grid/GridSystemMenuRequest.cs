using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridSystemMenuRequest : GridParameters , IRequest<Result<Grid<SystemMenuModel>>>;
