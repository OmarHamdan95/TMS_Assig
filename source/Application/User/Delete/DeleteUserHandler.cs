using TMS.Database;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record DeleteUserHandler : IRequestHandler<DeleteUserRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthRepository _authRepository;
    private readonly IUserRepository _userRepository;

    public DeleteUserHandler
    (
        IUnitOfWork unitOfWork,
        IAuthRepository authRepository,
        IUserRepository userRepository
    )
    {
        _unitOfWork = unitOfWork;
        _authRepository = authRepository;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(DeleteUserRequest request , CancellationToken cancellationToken)
    {
        await _authRepository.DeleteByUserIdAsync(request.Id);

        await _userRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
