using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetAttachmenHandler : IRequestHandler<GetAttachmenRequest, Result<AttachemntGroupModel>>
{
    private readonly IRepositoryBase<AttachmentGroup> _attachmentRepository;

    public GetAttachmenHandler(IRepositoryBase<AttachmentGroup> attachmentRepository) => _attachmentRepository = attachmentRepository;

    public async Task<Result<AttachemntGroupModel>> Handle(GetAttachmenRequest request , CancellationToken cancellationToken)
    {
        var attachemntGroup = await _attachmentRepository.GetModelAsync<AttachemntGroupModel>(request.Id);

        return new Result<AttachemntGroupModel>(attachemntGroup is null ? NotFound : OK, attachemntGroup);
    }
}
