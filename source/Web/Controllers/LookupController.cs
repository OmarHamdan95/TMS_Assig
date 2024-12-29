// using AjKpi.Application;
//
// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/lookup")]
// public sealed class LookupController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddLookupRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetLookupRequest(id)).ApiResult();
//
//     [HttpGet("autoComplate/{lookupCode}")]
//     public IActionResult autoComplate(string? lookupCode , string? text) => Mediator.Send(new AutoCompleteLookupRequest(lookupCode, text)).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteLookupRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridLookupRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpPatch("{id}/inactivate")]
//     public IActionResult Inactivate(long id) => Mediator.Send(new InactivateLookupRequest(id)).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListLookupRequest()).ApiResult();
//
//     [HttpPut("{id}")]
//     public IActionResult Update(long id, UpdateLookupRequest request)
//     {
//         request.Id = id;
//
//         return Mediator.Send(request).ApiResult();
//     }
// }
