using AjKpi.Model;

namespace AjKpi.Application;

public sealed record GetUserRequest(long Id) : IRequest<Result<UserModel>>;
