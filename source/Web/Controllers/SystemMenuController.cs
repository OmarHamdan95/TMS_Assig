// using AjKpi.Application;
//
// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/systemMenu")]
// public sealed class SystemMenuController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddSystemMenuRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetSystemMenuRequest(id)).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteSystemMenuRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridSystemMenuRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListSystemMenuRequest()).ApiResult();
//
//     // [HttpPut("{id}")]
//     // public IActionResult Update(long id, UpdateLookupRequest request)
//     // {
//     //     request.Id = id;
//     //
//     //     return Mediator.Send(request).ApiResult();
//     // }
// }
