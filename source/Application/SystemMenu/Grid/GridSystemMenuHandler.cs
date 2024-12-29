using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridSystemMenuHandler : IRequestHandler<GridSystemMenuRequest, Result<Grid<SystemMenuModel>>>
{
    private readonly IRepositoryBase<SystemMenu> _systemMenuRepository;

    public GridSystemMenuHandler(IRepositoryBase<SystemMenu> systemMenuRepository) => _systemMenuRepository = systemMenuRepository;

    public async Task<Result<Grid<SystemMenuModel>>> Handle(GridSystemMenuRequest request , CancellationToken cancellationToken)
    {
        var grid = await _systemMenuRepository.GridAsync<SystemMenuModel>(request);

        return new Result<Grid<SystemMenuModel>>(grid is null ? NotFound : OK, grid);
    }

}
