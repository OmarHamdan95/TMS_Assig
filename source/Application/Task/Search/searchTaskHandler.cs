using MapsterMapper;
using Microsoft.IdentityModel.Tokens;
using TMS.Application.Common;
using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record SearchTaskHandler : IRequestHandler<SearchTaskRequest, Result<Grid<TaskModel>>>
{
    private readonly IRepositoryBase<Task> _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public SearchTaskHandler(IRepositoryBase<Task> taskRepository, ICurrentUserService currentUserService) => (_taskRepository, _currentUserService)
        = (taskRepository, currentUserService);

    public Task<Result<Grid<TaskModel>>> Handle(SearchTaskRequest request, CancellationToken cancellationToken)
    {
        var query = _taskRepository.Queryable;

        long curentUserId = 0;
        long.TryParse(_currentUserService.UserId, out curentUserId);


        if (_currentUserService.Role.ToString() == UserRole.User.ToString())
            query = query.Where(_ => _.AssignedToId == curentUserId);


        if (request.Priority.HasValue)
            query = query.Where(_ => _.Priority == request.Priority);

        if (request.Status.HasValue)
            query = query.Where(_ => _.Status == request.Status);

        if (request.DueDate.HasValue)
            query = query.Where(_ => _.DueDate >= request.DueDate);

        if (!request.orderBy.IsNullOrEmpty())
        {
            if (request.orderBy.ToLower() == nameof(Task.Status))
                query = query.OrderByDescending(_ => _.Status).AsQueryable();
            if (request.orderBy.ToLower() == nameof(Task.Priority))
                query = query.OrderByDescending(_ => _.Priority).AsQueryable();
            if (request.orderBy.ToLower() == nameof(Task.DueDate))
                query = query.OrderByDescending(_ => _.DueDate).AsQueryable();
            if (request.orderBy.ToLower() == nameof(Task.CreatedDate))
                query = query.OrderByDescending(_ => _.CreatedDate).AsQueryable();
            else
                query = query.OrderByDescending(_ => _.CreatedDate).AsQueryable();
        }

        var data = query.Skip((request.pageIndex - 1) * request.pageSize).Take(request.pageSize).Select(_ => new TaskModel()
        {
            Id = _.Id,
            Title = _.Title,
            Description = _.Description,
            Status = (long)_.Status,
            Priority = (long)_.Priority,
            AssignedTo = new UserModel()
            {
                Id = _.AssignedTo.Id,
                NameAr = _.AssignedTo.NameAr,
                Email = _.AssignedTo.Email,
                UserName = _.AssignedTo.UserName,
                NameEn = _.AssignedTo.NameEn,
            },
            DueDate = _.DueDate,
            AssignedToId = _.AssignedToId,
        });


        var grid = new Grid<TaskModel>(data, new GridParameters());


        return System.Threading.Tasks.Task.FromResult(new Result<Grid<TaskModel>>(grid is null ? NotFound : OK, grid));
    }
}
