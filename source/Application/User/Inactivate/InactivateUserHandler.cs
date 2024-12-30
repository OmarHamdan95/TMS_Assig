using TMS.Database;
using TMS.Domain;
using static System.Net.HttpStatusCode;

namespace TMS.Application;

public sealed record InactivateUserHandler : IRequestHandler<InactivateUserRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public InactivateUserHandler
    (
        IUnitOfWork unitOfWork,
        IUserRepository userRepository
    )
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<Result> Handle(InactivateUserRequest request , CancellationToken cancellationToken)
    {
        var user = new User(request.Id);

        user.Inactivate();

        await _userRepository.UpdatePartialAsync(new { user.Id, user.Status });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
