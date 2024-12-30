using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record GridUserHandler : IRequestHandler<GridUserRequest, Result<Grid<UserModel>>>
{
    private readonly IUserRepository _userRepository;

    public GridUserHandler(IUserRepository userRepository ) => (_userRepository)= (userRepository);

    public async Task<Result<Grid<UserModel>>> Handle(GridUserRequest request , CancellationToken cancellationToken)
    {
        var grid = await _userRepository.GridAsync(request);

        return new Result<Grid<UserModel>>(grid is null ? NotFound : OK, grid);
    }
}
