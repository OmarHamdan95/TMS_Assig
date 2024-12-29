using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GridUserRequest : GridParameters , IRequest<Result<Grid<UserModel>>>;
