using TMS.Database;
using TMS.Domain;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record AddTaskHandler : IRequestHandler<AddTaskRequest, Result<long>>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Task> _taskRepository;

    public AddTaskHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Task> taskRepository
    )
    {
        _unitOfWork = unitOfWork;
        _taskRepository = taskRepository;
    }

    public async Task<Result<long>> Handle(AddTaskRequest request , CancellationToken cancellationToken)
    {
        var task = new Task(request.Title, request.Description,request.Status,request.Priority,request.DueDate,request.AssignedToId);

        await _taskRepository.AddAsync(task);

        await _unitOfWork.SaveChangesAsync();

        return new Result<long>(Created, task.Id);
    }
}
