// using AjKpi.Application;
//
// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/translation")]
// public sealed class TranslationController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddTranslationRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetTranslationRequest(id)).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteTranslationRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridTranslationRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListTranslationRequest()).ApiResult();
//
//     [HttpPut("{id}")]
//     public IActionResult Update(long id, UpdateTranslationRequest request)
//     {
//         request.Id = id;
//
//         return Mediator.Send(request).ApiResult();
//     }
// }
