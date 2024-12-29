using AjKpi.Database;
using AjKpi.Domain;
using System.Data;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record InactivateRoleHandler : IRequestHandler<InactivateRoleRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;

    public InactivateRoleHandler
    (
        IUnitOfWork unitOfWork,
        IRoleRepository roleRepository
    )
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<Result> Handle(InactivateRoleRequest request , CancellationToken cancellationToken)
    {
        var role = new Role(request.Id);


        await _roleRepository.UpdatePartialAsync(new { role.Id });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
