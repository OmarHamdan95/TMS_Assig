using AjKpi.Database;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetUserHandler : IRequestHandler<GetUserRequest, Result<UserModel>>
{
    private readonly IUserRepository _userRepository;

    public GetUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<Result<UserModel>> Handle(GetUserRequest request , CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetModelAsync(request.Id);

        return new Result<UserModel>(user is null ? NotFound : OK, user);
    }
}
