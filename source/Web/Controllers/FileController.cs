using AjKpi.Application;

namespace AjKpi.Web;

[ApiController]
[Route("api/files")]
public sealed class FileController : BaseController
{
    [DisableRequestSizeLimit]
    [HttpPost]
    public IActionResult Add() => Mediator.Send(new AddFileRequest(Request.Files())).ApiResult();

    [HttpGet("{id}")]
    public IActionResult Get(Guid id) => Mediator.Send(new GetFileRequest(id)).ApiResult();
}
