using TMS.Model;

namespace TMS.Application;

public sealed record GridUserRequest : GridParameters , IRequest<Result<Grid<UserModel>>>;
