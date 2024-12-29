using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListPermissionHandler : IRequestHandler<ListPermissionRequest, Result<IEnumerable<PermissionModel>>>
{
    private readonly IPermissionRepository _permissionRepository;

    public ListPermissionHandler(IPermissionRepository permissionRepository) => _permissionRepository = permissionRepository;

    public async Task<Result<IEnumerable<PermissionModel>>> Handle(ListPermissionRequest request , CancellationToken cancellationToken)
    {
        var permissions = await _permissionRepository.ListModelAsync<PermissionModel>();

        return new Result<IEnumerable<PermissionModel>>(permissions is null ? NotFound : OK, permissions);
    }
}
