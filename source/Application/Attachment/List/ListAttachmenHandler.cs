using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record ListAttachmenHandler : IRequestHandler<ListAttachmenRequest, Result<IEnumerable<AttachemntGroupModel>>>
{
    private readonly IRepositoryBase<AttachmentGroup> _attachmentRepository;

    public ListAttachmenHandler(IRepositoryBase<AttachmentGroup> attachmentRepository) => _attachmentRepository = attachmentRepository;

    public async Task<Result<IEnumerable<AttachemntGroupModel>>> Handle(ListAttachmenRequest request , CancellationToken cancellationToken)
    {
        var attachemntGroups = await _attachmentRepository.ListModelAsync<AttachemntGroupModel>();

        return new Result<IEnumerable<AttachemntGroupModel>>(attachemntGroups is null ? NotFound : OK, attachemntGroups);
    }
}
