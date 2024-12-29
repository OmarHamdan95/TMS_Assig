using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdateDepartmentHandler : IRequestHandler<UpdateDepartmentRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentRepository _departmentRepository;

    public UpdateDepartmentHandler
    (
        IUnitOfWork unitOfWork,
        IDepartmentRepository departmentRepository
    )
    {
        _unitOfWork = unitOfWork;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result> Handle(UpdateDepartmentRequest request , CancellationToken cancellationToken)
    {
        var department = await _departmentRepository.GetAsync(request.Id);

        if (department is null) return new Result(NotFound);

        department.UpdateDepartment(request.NameAr, request.NameEn);

        await _departmentRepository.UpdateAsync(department);

        // Call Audit Service (Old Value , New Value);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
