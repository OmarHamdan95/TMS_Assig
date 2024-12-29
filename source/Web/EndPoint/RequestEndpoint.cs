
namespace AjKpi.Web;

public static class RequestEndpoint
{
    public static void RegisterReqeustEndpoints(this IEndpointRouteBuilder routes)
    {
        var reqeust = routes.MapGroup("/api/reqeust").RequireAuthorization().WithTags(nameof(RequestEndpoint));

        reqeust.MapPost("",
            async (IMediator mediator, AddRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        reqeust.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetRequest(id));
            return Results.Ok(result.Value);
        });

        reqeust.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteRequest(id));
                return Results.Ok(result);
            });

        reqeust.MapPost("grid",
            async (IMediator mediator, [FromBody]GridRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });


        reqeust.MapPost("gridWf",
            async (IMediator mediator, [FromBody]GridWfTransactionReqeust request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        // menu.MapPatch("{id}/inactivate",
        //     async (IMediator mediator, long id) =>
        //     {
        //         var result = await mediator.Send(new InactivateUserRequest(id));
        //         return Results.Ok(result);
        //     });

        reqeust.MapPut("update", async (IMediator mediator, UpdateRequest request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });


        reqeust.MapPut("updateStatus",  [AllowAnonymous] async (IMediator mediator, UpdateRequestStatus request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });

        reqeust.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListRequest());
                return Results.Ok(result.Value);
            });

        // menu.MapPut("{id}",  async (IMediator mediator, long id, UpdateUserRequest request) =>
        // {
        //     request.Id = id;
        //     var result = await mediator.Send(request);
        //     return Results.Ok(result);
        // });
    }
}
