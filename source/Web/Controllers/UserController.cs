// using AjKpi.Application;
//
// namespace AjKpi.Web;
//
// [ApiController]
// [Route("api/users")]
// public sealed class UserController : BaseController
// {
//     [HttpPost]
//     public IActionResult Add(AddUserRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpDelete("{id}")]
//     public IActionResult Delete(long id) => Mediator.Send(new DeleteUserRequest(id)).ApiResult();
//
//     [HttpGet("{id}")]
//     public IActionResult Get(long id) => Mediator.Send(new GetUserRequest(id)).ApiResult();
//
//     [HttpGet("grid")]
//     public IActionResult Grid([FromQuery] GridUserRequest request) => Mediator.Send(request).ApiResult();
//
//     [HttpPatch("{id}/inactivate")]
//     public IActionResult Inactivate(long id) => Mediator.Send(new InactivateUserRequest(id)).ApiResult();
//
//     [HttpGet]
//     public IActionResult List() => Mediator.Send(new ListUserRequest()).ApiResult();
//
//     [HttpPut("{id}")]
//     public IActionResult Update(long id, UpdateUserRequest request)
//     {
//         request.Id = id;
//
//         return Mediator.Send(request).ApiResult();
//     }
// }
