using AjKpi.Database;
using AjKpi.Domain;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record DeleteAttachmenHandler : IRequestHandler<DeleteAttachmenRequest , Result>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepositoryBase<AttachmentGroup> _attachmentRepository;

    public DeleteAttachmenHandler
    (
        IUnitOfWork unitOfWork,
        IRepositoryBase<AttachmentGroup> attachmentRepository
    )
    {
        _unitOfWork = unitOfWork;
        _attachmentRepository = attachmentRepository;
    }

    public async Task<Result> Handle(DeleteAttachmenRequest request , CancellationToken cancellationToken)
    {

        await _attachmentRepository.DeleteEntityAsync(request.Id);

        await _unitOfWork.SaveChangesAsync();

        return new Result(NoContent);
    }
}
