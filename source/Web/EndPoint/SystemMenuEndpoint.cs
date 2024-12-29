namespace AjKpi.Web;

public static class SystemMenuEndpoint
{
    public static void RegisterSystemMenuEndpoints(this IEndpointRouteBuilder routes)
    {
        var menu = routes.MapGroup("/api/systemMenu").RequireAuthorization().WithTags(nameof(SystemMenuEndpoint));

        menu.MapPost("",
            async (IMediator mediator, AddSystemMenuRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        menu.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetSystemMenuRequest(id));
            return Results.Ok(result.Value);
        });

        menu.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteSystemMenuRequest(id));
                return Results.Ok(result);
            });

        menu.MapPost("grid",
            async (IMediator mediator, [FromBody]GridSystemMenuRequest request) =>
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

        menu.MapGet("list/{moduleCode}",
            async (IMediator mediator,string moduleCode) =>
            {
                var result = await mediator.Send(new ListSystemMenuRequest(moduleCode));
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
