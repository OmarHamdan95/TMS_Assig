// using AjKpi.Application;
//
// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/language")]
// public sealed class LanguageController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddLanguageRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetLanguageRequest(id)).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteLanguageRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridLanguageRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpPatch("{id}/inactivate")]
//     public IActionResult Inactivate(long id) => Mediator.Send(new InactivateLanguageRequest(id)).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListLanguageRequest()).ApiResult();
//
// }
