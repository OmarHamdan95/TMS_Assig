using AjKpi.Application.Common;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Shared.Templating;

namespace AjKpi.Application;
using static System.Net.HttpStatusCode;

public sealed record AddRequestHandler : IRequestHandler<AddRequest, Result<RequestResult>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Request> _requestRepository;
    private readonly IWFRepositoryBase<RequestType> _requestTypeRepository;
    private readonly IWFRepositoryBase<RequestStatus> _requestStatusRepository;
    private readonly ICurrentUserService _currentUserService;
    public AddRequestHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Request> requestRepository,
        IWFRepositoryBase<RequestType> requestTypeRepository ,
        IWFRepositoryBase<RequestStatus> requestStatusRepository,
        ICurrentUserService currentUserService
    )
    {
        _unitOfWork = unitOfWork;
        _requestRepository = requestRepository;
        _requestTypeRepository = requestTypeRepository;
        _requestStatusRepository = requestStatusRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result<RequestResult>> Handle(AddRequest command , CancellationToken cancellationToken)
    {

        JObject data = JObject.Parse(command.request.Data);


        var type = await _requestTypeRepository.Queryable
                       .Include(e => e.Statuses.Where(s => s.Code == command.request.Status))
                       .FirstOrDefaultAsync(x => x.Code == command.request.Type) ??
                   throw new Exception("INVALID_REQUEST_TYPE");

        var status = type.Statuses.FirstOrDefault() ?? throw new Exception("INVALID_REQUEST_STATUS");

        if (!status.IsStartingState.HasValue || !status.IsStartingState.Value)
        {
            throw new Exception("NOT_STARTING_STATE");
        }

        var count = await _requestRepository
            .Queryable
            .Where(r => r.TypeId == type.Id)
            .CountAsync();


        var request = new Request(data?.ToString(Formatting.None) ?? "", status.Id, type.Id,
            NameTemplateResolver.Resolve(type?.RequestNumberTemplate, data, count).First() ?? null,
            NameTemplateResolver.Resolve(type?.CompositeKeyTemplate, data) ?? null,
            NameTemplateResolver.Resolve(type?.GlobalCompositeKeyTemplate, data) ?? null,
            _currentUserService.UserId, _currentUserService.DepartmentId, command.request.ExternalId,
            command.request.InitDepartmentCode , command.request.TargetDepartmentCode,command.request.TargetRoleCode);


        if (type.PreventConcurrentRequests.HasValue && type.PreventConcurrentRequests.Value)
        {
            if (await _requestRepository.Queryable
                    .Where(e => e.CompositeKeys.Any(ck => request.CompositeKeys.Contains(ck)))
                    .Where(e => !e.Status.IsEndState.Value)
                    .Where(e => e.TypeId == type.Id)
                    .AnyAsync())
            {
                throw new Exception("ENTITY_HAS_PENDING_REQUESTS");
            }
        }


        if (type.ConcurrencyPreventedTypeCodes != null
            && type.ConcurrencyPreventedTypeCodes.Any())
        {
            var types = type.ConcurrencyPreventedTypeCodes.ToHashSet();

            var pendingRequests = await _requestRepository.Queryable
                .Where(e => e.GlobalCompositeKeys.Any(gck => request.GlobalCompositeKeys.Contains(gck)))
                .Where(e => !e.Status.IsEndState.Value)
                .Where(e => types.Contains(e.Type.Code))
                .AnyAsync();

            if (pendingRequests)
            {
                throw new Exception("ENTITY_HAS_PENDING_GLOBAL_REQUESTS");
            }
        }

        if (type.MaxAllowedRequests != null)
        {
            var existingRequestsCount = await _requestRepository.Queryable
                .Where(e => e.TypeId == type.Id)
                .Where(e => e.CreatedBy == request.CreatedBy)
                .Where(e => e.Id != request.Id)
                .CountAsync();

            if (existingRequestsCount >= type.MaxAllowedRequests)
            {
                throw new Exception("MAX_REQUESTS_LIMIT_EXCEEDED");
            }
        }


        await _requestRepository.AddAsync(request);

        await _unitOfWork.SaveChangesAsync();



        return new Result<RequestResult>(Created, new RequestResult()
        {
            Id = request.Id,
            Number = request.Number,
            CompositeKeys = request.CompositeKeys,
            GlobalCompositeKeys = request.GlobalCompositeKeys,
            TypeCode = type.Code
        });
    }

    public static JObject ConvertToJObject(object obj)
    {
        // Serialize the object to JSON string
        string jsonString = JsonConvert.SerializeObject(obj ,  new JsonSerializerSettings
        {
            ReferenceLoopHandling =  ReferenceLoopHandling.Ignore
        });

        // Parse the JSON string into a JObject
        return JObject.Parse(jsonString);
    }
}
