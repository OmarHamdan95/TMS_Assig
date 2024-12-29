using AjKpi.Database;
using AjKpi.Domain;
using AjKpi.Model;
using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GridAttachmenHandler : IRequestHandler<GridAttachmenRequest, Result<Grid<AttachemntGroupModel>>>
{
    private readonly IRepositoryBase<AttachmentGroup> _attachmentRepository;

    public GridAttachmenHandler(IRepositoryBase<AttachmentGroup> attachmentRepository) => _attachmentRepository = attachmentRepository;

    public async Task<Result<Grid<AttachemntGroupModel>>> Handle(GridAttachmenRequest request , CancellationToken cancellationToken)
    {
        var grid = await _attachmentRepository.GridAsync<AttachemntGroupModel>(request);

        return new Result<Grid<AttachemntGroupModel>>(grid is null ? NotFound : OK, grid);
    }

}
