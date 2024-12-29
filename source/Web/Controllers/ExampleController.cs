// using AjKpi.Application;
//
// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/examples")]
// public sealed class ExampleController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddExampleRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteExampleRequest(id)).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetExampleRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridExampleRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListExampleRequest()).ApiResult();
//
//     [HttpPut("{id}")]
//     public IActionResult Update(long id, UpdateExampleRequest request)
//     {
//         request.Id = id;
//
//         return Mediator.Send(request).ApiResult();
//     }
// }
