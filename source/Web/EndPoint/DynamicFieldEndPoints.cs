// using TMS.Application;
//
// namespace TMS.Web;
//
// public static class DynamicFieldEndPoints
// {
//     public static void RegisterDynamicFieldEndPoints(this IEndpointRouteBuilder routes)
//     {
//         var dynamicField = routes.MapGroup("/api/DynamicField").RequireAuthorization()
//             .WithTags(nameof(DynamicFieldEndPoints));
//
//         dynamicField.MapPost("",
//             (IMediator mediator, AddDynamicFieldRequest request) =>
//             {
//                 return Results.Ok(mediator.Send(request).ApiResult());
//             });
//
//
//         dynamicField.MapGet("{id}",
//             (IMediator mediator, long id) =>
//             {
//                 return Results.Ok(mediator.Send(new GetDynamicFieldRequest(id)).ApiResult());
//             });
//
//         dynamicField.MapDelete("{id}",
//             (IMediator mediator, long id) =>
//             {
//                 return Results.Ok(mediator.Send(new DeleteDynamicFieldRequest(id)).ApiResult());
//             });
//
//         dynamicField.MapPost("grid",
//             (IMediator mediator, GridDynamicFieldRequest request) =>
//             {
//                 return Results.Ok(mediator.Send(request).ApiResult());
//             });
//
//         dynamicField.MapGet("list",
//             (IMediator mediator) =>
//             {
//                 return Results.Ok(mediator.Send(new ListDynamicFieldRequest()).ApiResult());
//             });
//
//         dynamicField.MapPut("{id}", (IMediator mediator, long id, UpdateDynamicFieldRequest request) =>
//         {
//             request.Id = id;
//
//             return Results.Ok(mediator.Send(request).ApiResult());
//         });
//     }
// }
