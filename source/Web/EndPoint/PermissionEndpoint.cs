using AjKpi.Application;

namespace AjKpi.Web;

public static class PermissionEndpoint
{
    public static void RegisterPermissionEndpoints(this IEndpointRouteBuilder routes)
    {
        var lookup = routes.MapGroup("/api/permission").RequireAuthorization().WithTags(nameof(PermissionEndpoint));


        lookup.MapPost("",
            async (IMediator mediator, AddPermissionRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        lookup.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetPermissionRequest(id));
            return Results.Ok(result.Value);
        });

        //lookup.MapGet("autoComplate/{lookupCode}", async (IMediator mediator, string? lookupCode , string? text) =>
        //{
        //    var result = await mediator.Send(new AutoCompletePermissionRequest(lookupCode, text));
        //    return Results.Ok(result.Value);
        //});

        lookup.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeletePermissionRequest(id));
                return Results.Ok(result);
            });

        lookup.MapPost("grid",
            async (IMediator mediator, [FromBody]GridPermissionRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        lookup.MapPatch("{id}/inactivate",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new InactivatePermissionRequest(id));
                return Results.Ok(result);
            });

        lookup.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListPermissionRequest());
                return Results.Ok(result.Value);
            });

        lookup.MapPut("{id}",  async (IMediator mediator, long id, UpdatePermissionRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
