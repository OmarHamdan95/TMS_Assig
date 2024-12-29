using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetPermissionHandler : IRequestHandler<GetPermissionRequest, Result<PermissionModel>>
{
    private readonly IPermissionRepository _permissionRepository;

    public GetPermissionHandler(IPermissionRepository permissionRepository) => _permissionRepository = permissionRepository;

    public async Task<Result<PermissionModel>> Handle(GetPermissionRequest request , CancellationToken cancellationToken)
    {
        var permission = await _permissionRepository.GetModelAsync<PermissionModel>(request.Id);

        return new Result<PermissionModel>(permission is null ? NotFound : OK, permission);
    }
}
