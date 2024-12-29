using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record InactivateDepartmentHandler : IRequestHandler<InactivateDepartmentRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentRepository _departmentRepository;

    public InactivateDepartmentHandler
    (
        IUnitOfWork unitOfWork,
        IDepartmentRepository departmentRepository
    )
    {
        _unitOfWork = unitOfWork;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> Handle(InactivateDepartmentRequest request , CancellationToken cancellationToken)
    {
        var department = new Department(request.Id);

        department.Inactivate();

        await _departmentRepository.UpdatePartialAsync(new { department.Id, department.ValidTo });

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
