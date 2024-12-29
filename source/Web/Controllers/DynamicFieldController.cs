// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/dynamicField")]
// public sealed class DynamicFieldController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddDynamicFieldRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetDynamicFieldRequest(id)).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteDynamicFieldRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridDynamicFieldRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListDynamicFieldRequest()).ApiResult();
//
//     [HttpPut("{id}")]
//     public IActionResult Update(long id, UpdateDynamicFieldRequest request)
//     {
//         request.Id = id;
//
//         return Mediator.Send(request).ApiResult();
//     }
// }
