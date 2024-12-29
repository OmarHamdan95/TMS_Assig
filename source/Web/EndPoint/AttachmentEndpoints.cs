
using AjKpi.Application;

namespace AjKpi.Web;

public static class AttachmentEndpoints
{
    public static void RegisterAttachmentEndpoints(this IEndpointRouteBuilder routes)
    {
        var attachemnt = routes.MapGroup("/api/attachemnt").RequireAuthorization().WithTags(nameof(AttachmentEndpoints));

        attachemnt.MapPost("",
            (IMediator mediator, AddAttachmenRequest request) =>
            {
                return Results.Ok(mediator.Send(request).ApiResult());
            });

        attachemnt.MapGet("{id}",
            (IMediator mediator, long id) =>
            {
                return Results.Ok(mediator.Send(new GetAttachmenRequest(id)).ApiResult());
            });

        attachemnt.MapDelete("{id}",
            (IMediator mediator, long id) =>
            {
                return Results.Ok(mediator.Send(new DeleteAttachmenRequest(id)).ApiResult());
            });

        attachemnt.MapPost("grid",
            (IMediator mediator, GridAttachmenRequest request) =>
            {
                return Results.Ok(mediator.Send(request).ApiResult());
            });

        attachemnt.MapGet("list",
            (IMediator mediator) =>
            {
                return Results.Ok(mediator.Send(new ListAttachmenRequest()).ApiResult());
            });

        attachemnt.MapPut("{id}", (IMediator mediator, long id, UpdateAttachmenRequest request) =>
        {
            request.Id = id;
            return Results.Ok(mediator.Send(request).ApiResult());
        });
        //users.MapPost("", (AddAttachmenRequest request) => Mediator.Send(request).ApiResult());
    }
}
