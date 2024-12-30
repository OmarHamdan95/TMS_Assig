using TMS.Model;

namespace TMS.Application;

public sealed record ListUserRequest : IRequest<Result<IEnumerable<UserModel>>>;
