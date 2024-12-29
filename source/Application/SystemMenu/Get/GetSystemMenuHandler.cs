using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetSystemMenuHandler : IRequestHandler<GetSystemMenuRequest, Result<SystemMenuModel>>
{
    private readonly IRepositoryBase<SystemMenu> _systemMenuRepository;

    public GetSystemMenuHandler(IRepositoryBase<SystemMenu> systemMenuRepository) => _systemMenuRepository = systemMenuRepository;

    public async Task<Result<SystemMenuModel>> Handle(GetSystemMenuRequest request , CancellationToken cancellationToken)
    {
        var systemMenu = await _systemMenuRepository.GetModelAsync<SystemMenuModel>(request.Id);

        return new Result<SystemMenuModel>(systemMenu is null ? NotFound : OK, systemMenu);
    }
}
