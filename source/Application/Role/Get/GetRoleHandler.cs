using AjKpi.Database;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetRoleHandler : IRequestHandler<GetRoleRequest, Result<RoleModel>>
{
    private readonly IRoleRepository _roleRepository;

    public GetRoleHandler(IRoleRepository roleRepository) => _roleRepository = roleRepository;

    public async Task<Result<RoleModel>> Handle(GetRoleRequest request , CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetModelAsync<RoleModel>(request.Id);

        return new Result<RoleModel>(role is null ? NotFound : OK, role);
    }
}
