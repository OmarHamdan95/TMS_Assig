using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;

namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record AddPermissionHandler : IRequestHandler<AddPermissionRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPermissionRepository _permissionRepository;

    public AddPermissionHandler
    (
        IUnitOfWork unitOfWork,
        IPermissionRepository permissionRepository
    )
    {
        _unitOfWork = unitOfWork;
        _permissionRepository = permissionRepository;
    }

    public async Task<Result<long>> Handle(AddPermissionRequest request, CancellationToken cancellationToken)
    {
        var permission = new Permission(request.Code,
            request.NameAr,
            request.NameEn,
            request.RoleId
            );



        await _permissionRepository.AddAsync(permission);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, permission.Id);
        // throw new NotImplementedException();
    }
}
