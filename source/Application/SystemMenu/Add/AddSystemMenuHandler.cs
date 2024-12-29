using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
namespace AjKpi.Application;
using static System.Net.HttpStatusCode;

public sealed record AddSystemMenuHandler : IRequestHandler<AddSystemMenuRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<SystemMenu> _systemMenuRepository;

    public AddSystemMenuHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<SystemMenu> languageRepository
    )
    {
        _unitOfWork = unitOfWork;
        _systemMenuRepository = languageRepository;
    }

    public async Task<Result<long>> Handle(AddSystemMenuRequest request , CancellationToken cancellationToken)
    {

        var systemMenu = new SystemMenu(request.Name, request.Icon , request.Route , request.Permission,
            request.Parent.Adapt<SystemMenu>() , request.ModuleCode, request.Child.Adapt<List<SystemMenu>>());

        await _systemMenuRepository.AddAsync(systemMenu);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, systemMenu.Id);
        // throw new NotImplementedException();
    }
}
