// using AjKpi.Application;
//
// namespace Epmo.Web;
//
// [ApiController]
// [Route("api/attachemnt")]
// public sealed class AttachmentController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddAttachmenRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetAttachmenRequest(id)).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteAttachmenRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridAttachmenRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListAttachmenRequest()).ApiResult();
//
//     [HttpPut("{id}")]
//     public IActionResult Update(long id, UpdateAttachmenRequest request)
//     {
//         request.Id = id;
//
//         return Mediator.Send(request).ApiResult();
//     }
// }
