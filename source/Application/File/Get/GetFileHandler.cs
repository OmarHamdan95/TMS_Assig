using static System.Net.HttpStatusCode;

namespace AjKpi.Application;

public sealed record GetFileHandler : IRequestHandler<GetFileRequest, Result<BinaryFile>>
{
    public async Task<Result<BinaryFile>> Handle(GetFileRequest request , CancellationToken cancellationToken)
    {
        var file = await BinaryFile.ReadAsync("Files", request.Id);

        return new Result<BinaryFile>(file is null ? NotFound : OK, file);
    }
}
