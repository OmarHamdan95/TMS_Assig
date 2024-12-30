using TMS.Model;

namespace TMS.Application;

public sealed record GetUserRequest(long Id) : IRequest<Result<UserModel>>;
