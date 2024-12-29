using AjKpi.Database;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeleteRoleHandler : IRequestHandler<DeleteRoleRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IAuthRepository _authRepository;
    private readonly IRoleRepository _roleRepository;

    public DeleteRoleHandler
    (
        IUnitOfWork unitOfWork,
        IAuthRepository authRepository,
        IRoleRepository roleRepository
    )
    {
        _unitOfWork = unitOfWork;
        _authRepository = authRepository;
        _roleRepository = roleRepository;
    }

    public async Task<Result> Handle(DeleteRoleRequest request , CancellationToken cancellationToken)
    {

        await _roleRepository.DeleteAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
