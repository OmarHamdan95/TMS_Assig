using AjKpi.Database;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdateRoleHandler : IRequestHandler<UpdateRoleRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;

    public UpdateRoleHandler
    (
        IUnitOfWork unitOfWork,
        IRoleRepository roleRepository
    )
    {
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<Result> Handle(UpdateRoleRequest request, CancellationToken cancellationToken)
    {
        var role = await _roleRepository.GetAsync(request.Id);

        if (role is null) return new Result(NotFound);

        role.UpdateName(request.NameAr, request.NameEn);


        await _roleRepository.UpdateAsync(role);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
