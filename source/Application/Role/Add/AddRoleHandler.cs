using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record AddRoleHandler : IRequestHandler<AddRoleRequest, Result<long>>
{
    private readonly IHashService _hashService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRoleRepository _roleRepository;

    public AddRoleHandler
    (
        IHashService hashService,
        IUnitOfWork unitOfWork,
        IRoleRepository roleRepository
    )
    {
        _hashService = hashService;
        _unitOfWork = unitOfWork;
        _roleRepository = roleRepository;
    }

    public async Task<Result<long>> Handle(AddRoleRequest request , CancellationToken cancellationToken)
    {
        var role = new Role(request.NameAr, request.NameEn, request?.DepartmentId , request.Code);




        await _roleRepository.AddAsync(role);


        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, role.Id);
    }
}
