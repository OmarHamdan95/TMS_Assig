using TMS.Application.Common;
using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record GetTaskHandler : IRequestHandler<GetTaskRequest, Result<TaskModel>>
{
    private readonly IRepositoryBase<Task> _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public GetTaskHandler(IRepositoryBase<Task> taskRepository, ICurrentUserService currentUserService) =>
        (_taskRepository, _currentUserService) = (taskRepository, currentUserService);

    public async Task<Result<TaskModel>> Handle(GetTaskRequest request, CancellationToken cancellationToken)
    {

        long curentUserId = 0;
         long.TryParse(_currentUserService.UserId, out curentUserId);

        TaskModel data = null;

        if (_currentUserService.Role.ToString() == UserRole.Admin.ToString())
            data = await _taskRepository.GetModelAsync<TaskModel>(request.Id);

        else
            data = _taskRepository.Queryable.Where(_ => _.Id == request.Id && _.AssignedToId == curentUserId).Select(_ => new TaskModel()
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
            }).FirstOrDefault();

        return new Result<TaskModel>(data is null ? NotFound : OK, data);
    }
}
