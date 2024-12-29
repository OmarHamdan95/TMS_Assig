using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridPermissionHandler : IRequestHandler<GridPermissionRequest, Result<Grid<PermissionModel>>>
{
    private readonly IPermissionRepository _permissionRepository;

    public GridPermissionHandler(IPermissionRepository permissionRepository) => _permissionRepository = permissionRepository;

    public async Task<Result<Grid<PermissionModel>>> Handle(GridPermissionRequest request , CancellationToken cancellationToken)
    {
        var grid = await _permissionRepository.GridAsync<PermissionModel>(request);

        return new Result<Grid<PermissionModel>>(grid is null ? NotFound : OK, grid);
    }

}
