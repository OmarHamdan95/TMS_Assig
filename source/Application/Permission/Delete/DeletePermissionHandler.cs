using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeletePermissionHandler : IRequestHandler<DeletePermissionRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPermissionRepository _permissionRepository;

    public DeletePermissionHandler
    (
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository
    )
    {
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
    }

    public async Task<Result> Handle(DeletePermissionRequest request , CancellationToken cancellationToken)
    {

        await _permissionRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
