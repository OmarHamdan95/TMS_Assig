using AjKpi.Database;
using AjKpi.Domain;
using Mapster;
using Microsoft.EntityFrameworkCore;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record UpdateRequestHandler : IRequestHandler<UpdateRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Request> _requestRepository;

    public UpdateRequestHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Request> requestRepository
    )
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
    }

    public async Task<Result> Handle(UpdateRequest command , CancellationToken cancellationToken)
    {

        var request = await _requestRepository.Queryable
            .Include(e => e.Status)
            .Include(e => e.Type.Statuses)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == command.RequestId) ?? throw new Exception("REQUEST_NOT_FOUND");


        var currentStatus = request.Status;
        if (currentStatus.IsEndState.HasValue && currentStatus.IsEndState.Value)
        {
            throw new Exception("REQUEST_ALREADY_COMPLETED");
        }

        var newStatus = request.Type.Statuses
            .FirstOrDefault(s => s.Code == command.Status) ?? throw new Exception("STATUS_NOT_FOUND");

        if (!currentStatus.NextStatusCodes.Any(code => code == newStatus.Code))
        {
            throw new Exception("INVALID_STATUS_CODE");
        }

        var isSelfAction = request.CreatedBy == command.ActorId;

        if ((!newStatus.SelfAllowed && isSelfAction) ||
            (newStatus.Roles.Any() &&
             !newStatus.Roles.Any(roleCode => roleCode == command.ActorRole)))
        {
            throw new Exception("FORBIDDEN_ACTION");
        }

        await _requestRepository.Queryable.Where(r => r.Id == request.Id)
            .ExecuteUpdateAsync(e =>
                e.SetProperty(x => x.StatusId, x => newStatus.Id)
                    .SetProperty(x => x.Note, x => command.Note));


        return new Result(NoContent);
    }
}
