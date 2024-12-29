using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Domain.Common;
using Mapster;

namespace AjKpi.Application;

using static System.Net.HttpStatusCode;

public sealed record AddDepartmentHandler : IRequestHandler<AddDepartmentRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IDepartmentRepository _departmentRepository;

    public AddDepartmentHandler
    (
        IUnitOfWork unitOfWork,
        IDepartmentRepository departmentRepository
    )
    {
        _unitOfWork = unitOfWork;
        _departmentRepository = departmentRepository;
    }

    public async Task<Result<long>> Handle(AddDepartmentRequest request, CancellationToken cancellationToken)
    {
        var lookup = new Department(request.Code,
            request.NameAr,
            request.NameEn);

        await _departmentRepository.AddAsync(lookup);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, lookup.Id);
    }
}
