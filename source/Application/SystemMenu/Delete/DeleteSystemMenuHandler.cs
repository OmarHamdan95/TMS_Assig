using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeleteSystemMenuHandler : IRequestHandler<DeleteSystemMenuRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<SystemMenu> _systemMenuRepository;

    public DeleteSystemMenuHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<SystemMenu> systemMenuRepository
    )
    {
        _unitOfWork = unitOfWork;
        _systemMenuRepository = systemMenuRepository;
    }

    public async Task<Result> Handle(DeleteSystemMenuRequest request , CancellationToken cancellationToken)
    {

        await _systemMenuRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
