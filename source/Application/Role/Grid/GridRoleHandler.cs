using AjKpi.Database;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridRoleHandler : IRequestHandler<GridRoleRequest, Result<Grid<RoleModel>>>
{
    private readonly IRoleRepository _roleRepository;

    public GridRoleHandler(IRoleRepository roleRepository ) => (_roleRepository)= (roleRepository);

    public async Task<Result<Grid<RoleModel>>> Handle(GridRoleRequest request , CancellationToken cancellationToken)
    {
        var grid = await _roleRepository.GridAsync<RoleModel>(request);

        return new Result<Grid<RoleModel>>(grid is null ? NotFound : OK, grid);
    }
}
