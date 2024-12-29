using AjKpi.Database;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListUserHandler : IRequestHandler<ListUserRequest, Result<IEnumerable<UserModel>>>
{
    private readonly IUserRepository _userRepository;

    public ListUserHandler(IUserRepository userRepository) => _userRepository = userRepository;

    public async Task<Result<IEnumerable<UserModel>>> Handle(ListUserRequest request , CancellationToken cancellationToken)
    {
        var users = await _userRepository.ListModelAsync();

        return new Result<IEnumerable<UserModel>>(users is null ? NotFound : OK, users);
    }
}
