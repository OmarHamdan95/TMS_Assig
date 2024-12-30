using MapsterMapper;
using Microsoft.IdentityModel.Tokens;
using TMS.Application.Common;
using TMS.Database;
using TMS.Model;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record GridTaskHandler : IRequestHandler<GridTaskRequest, Result<Grid<TaskModel>>>
{
    private readonly IRepositoryBase<Task> _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public GridTaskHandler(IRepositoryBase<Task> taskRepository , ICurrentUserService currentUserService ) => (_taskRepository , _currentUserService)
        = (taskRepository , currentUserService);

    public async Task<Result<Grid<TaskModel>>> Handle(GridTaskRequest request , CancellationToken cancellationToken)
    {


        if (_currentUserService.Role.ToString() == UserRole.User.ToString())
        {
            if (request.Filters.IsNullOrEmpty())
            {
                request.Filters = new Filters();
                request.Filters.Add(new Filter()
                {
                    Property = nameof(Task.AssignedToId),
                    Comparison = "",
                    Value = _currentUserService.UserId
                });
            }
            else
                request.Filters.Add(new Filter()
                {
                    Property = nameof(Task.AssignedToId),
                    Comparison = "",
                    Value = _currentUserService.UserId
                });
        }


        var grid = await _taskRepository.GridAsync<TaskModel>(request);


        return new Result<Grid<TaskModel>>(grid is null ? NotFound : OK, grid);
    }
}
