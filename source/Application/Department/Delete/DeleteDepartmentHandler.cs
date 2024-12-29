using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeleteDepartmentHandler : IRequestHandler<DeleteDepartmentRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentRepository _departmentRepository;

    public DeleteDepartmentHandler
    (
        IUnitOfWork unitOfWork,
        IDepartmentRepository departmentRepository
    )
    {
        _unitOfWork = unitOfWork;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> Handle(DeleteDepartmentRequest request , CancellationToken cancellationToken)
    {

        await _departmentRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
