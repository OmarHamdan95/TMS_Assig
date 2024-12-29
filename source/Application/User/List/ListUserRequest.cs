using AjKpi.Model;

namespace AjKpi.Application;

public sealed record ListUserRequest : IRequest<Result<IEnumerable<UserModel>>>;
