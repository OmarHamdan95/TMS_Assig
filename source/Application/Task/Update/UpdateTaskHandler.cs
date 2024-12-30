using TMS.Application.Common;
using TMS.Database;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record UpdateTaskHandler : IRequestHandler<UpdateTaskRequest, Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Task> _taskRepository;
    private readonly ICurrentUserService _currentUserService;

    public UpdateTaskHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Task> taskRepository,
        ICurrentUserService currentUserService
    )
    {
        _unitOfWork = unitOfWork;
        _taskRepository = taskRepository;
        _currentUserService = currentUserService;
    }

    public async Task<Result> Handle(UpdateTaskRequest request, CancellationToken cancellationToken)
    {

        long curentUserId = 0;
        long.TryParse(_currentUserService.UserId, out curentUserId);

        var task = await _taskRepository.GetAsync(request.Id);

        if (task is null) return new Result(NotFound);

        if (_currentUserService.Role.ToString() == UserRole.User.ToString()
            && task.AssignedToId != curentUserId)
            return new Result(NotFound);

        task.Update(request.Title, request.Description);

        task.UpdatePriority((long?)request.Priority ?? (long)task.Priority);
        task.UpdateStatus((long?)request.Status ?? (long)task.Status);
        task.UpdateAssignedTo(request.AssignedToId);
        task.UpdateDueDate(request.DueDate);

        await _taskRepository.UpdateAsync(task);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
