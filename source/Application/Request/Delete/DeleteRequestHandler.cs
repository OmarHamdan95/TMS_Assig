using AjKpi.Database;
using AjKpi.Domain;
using Microsoft.EntityFrameworkCore;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeleteRequestHandler : IRequestHandler<DeleteRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Request> _requestRepository;
    private readonly IWFRepositoryBase<RequestStatus> _requestStatusRepository;

    public DeleteRequestHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Request> requestRepository,
        IWFRepositoryBase<RequestStatus> requestStatusRepository
    )
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
        _requestStatusRepository = requestStatusRepository;
    }

    public async Task<Result> Handle(DeleteRequest command , CancellationToken cancellationToken)
    {

        var request = await _requestRepository.Queryable.AsNoTracking().FirstOrDefaultAsync(r => r.Id == command.Id, cancellationToken)
                      ?? throw new Exception("NOT_FOUND");


        var requestStatus = await _requestStatusRepository.Queryable
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.StatusId, cancellationToken);

        if (!requestStatus.IsDeletable.HasValue || !requestStatus.IsDeletable.Value)
        {
            throw new Exception("INVALID_STATUS_OPERATION");
        }

        await _requestRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
