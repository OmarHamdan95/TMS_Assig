using AjKpi.Database;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListRoleHandler : IRequestHandler<ListRoleRequest, Result<IEnumerable<RoleModel>>>
{
    private readonly IRoleRepository _roleRepository;

    public ListRoleHandler(IRoleRepository roleRepository) => _roleRepository = roleRepository;

    public async Task<Result<IEnumerable<RoleModel>>> Handle(ListRoleRequest request , CancellationToken cancellationToken)
    {
        var roles = await _roleRepository.ListModelAsync<RoleModel>();

        return new Result<IEnumerable<RoleModel>>(roles is null ? NotFound : OK, roles);
    }
}
