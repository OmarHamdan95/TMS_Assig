using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListSystemMenuHandler : IRequestHandler<ListSystemMenuRequest, Result<IEnumerable<SystemMenuModel>>>
{
    private readonly ISystemMenuRepository _systemMenuRepository;

    public ListSystemMenuHandler(ISystemMenuRepository systemMenuRepository) => _systemMenuRepository = systemMenuRepository;

    public async Task<Result<IEnumerable<SystemMenuModel>>> Handle(ListSystemMenuRequest request , CancellationToken cancellationToken)
    {
        var systemMenus = await _systemMenuRepository.ListModelAsync<SystemMenuModel>(request.ModuleCode);

        return new Result<IEnumerable<SystemMenuModel>>(systemMenus is null ? NotFound : OK, systemMenus);
    }
}
