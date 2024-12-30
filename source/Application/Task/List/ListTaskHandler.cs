using TMS.Application.Common;
using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record ListTaskHandler : IRequestHandler<ListTaskRequest, Result<IEnumerable<TaskModel>>>
{
    private readonly IRepositoryBase<Task> _taskRepository;
    private readonly ICurrentUserService _currentUserService;


    public ListTaskHandler(IRepositoryBase<Task> taskRepository, ICurrentUserService currentUserService) => (_taskRepository, _currentUserService)
        = (taskRepository, currentUserService);

    public async Task<Result<IEnumerable<TaskModel>>> Handle(ListTaskRequest request, CancellationToken cancellationToken)
    {

        long curentUserId = 0;
        long.TryParse(_currentUserService.UserId, out curentUserId);

        IEnumerable<TaskModel> tasks = null;
        if (_currentUserService.Role.ToString() == UserRole.Admin.ToString())
            tasks = await _taskRepository.ListModelAsync<TaskModel>();
        else
            tasks = _taskRepository.Queryable.Where(_=> _.AssignedToId == curentUserId).Select(_=> new TaskModel()
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
            }).ToList().AsEnumerable();

        return new Result<IEnumerable<TaskModel>>(tasks is null ? NotFound : OK, tasks);
    }
}
