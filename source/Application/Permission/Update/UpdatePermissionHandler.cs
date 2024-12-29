using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdatePermissionHandler : IRequestHandler<UpdatePermissionRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPermissionRepository _permissionRepository;

    public UpdatePermissionHandler
    (
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository
    )
    {
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
    }

    public async Task<Result> Handle(UpdatePermissionRequest request , CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetAsync(request.Id);

        if (permission is null) return new Result(NotFound);

        permission.UpdatePermission(request.NameAr, request.NameEn);

        await _permissionRepository.UpdateAsync(permission);

        // Call Audit Service (Old Value , New Value);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
