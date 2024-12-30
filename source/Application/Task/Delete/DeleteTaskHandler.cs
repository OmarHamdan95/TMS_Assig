using TMS.Database;
using static System.Net.HttpStatusCode;
using Task = TMS.Domain.Task;

namespace TMS.Application;

public sealed record DeleteTaskHandler : IRequestHandler<DeleteTaskRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<Task> _taskRepository;

    public DeleteTaskHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<Task> taskRepository
    )
    {
        _unitOfWork = unitOfWork;
        _taskRepository = taskRepository;
    }

    public async Task<Result> Handle(DeleteTaskRequest request , CancellationToken cancellationToken)
    {
        await _taskRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
