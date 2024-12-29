using AjKpi.Database;
using AjKpi.Domain;
using System.Security;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record InactivatePermissionHandler : IRequestHandler<InactivatePermissionRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPermissionRepository _permissionRepository;

    public InactivatePermissionHandler
    (
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository
    )
    {
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
    }

    public async Task<Result> Handle(InactivatePermissionRequest request , CancellationToken cancellationToken)
    {
        var permission = new Permission(request.Id);

       // lookup.Inactivate();

        await _permissionRepository.UpdatePartialAsync(new { permission.Id });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
