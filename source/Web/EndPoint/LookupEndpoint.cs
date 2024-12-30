using TMS.Application;
namespace TMS.Web;

public static class LookupEndpoint
{
    public static void RegisterLookupEndpoints(this IEndpointRouteBuilder routes)
    {
        var lookup = routes.MapGroup("/api/lookup").RequireAuthorization().WithTags(nameof(LookupEndpoint));


        lookup.MapPost("",
            async (IMediator mediator, AddLookupRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        lookup.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetLookupRequest(id));
            return Results.Ok(result.Value);
        });

        lookup.MapGet("autoComplate/{lookupCode}/{parentId}", async (IMediator mediator, string? lookupCode , long? parentId, string? text) =>
        {
            var result = await mediator.Send(new AutoCompleteLookupRequest(lookupCode , parentId, text));
            return Results.Ok(result.Value);
        });

        lookup.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteLookupRequest(id));
                return Results.Ok(result);
            });

        lookup.MapPost("grid",
            async (IMediator mediator, [FromBody]GridLookupRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        lookup.MapPatch("{id}/inactivate",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new InactivateLookupRequest(id));
                return Results.Ok(result);
            });

        lookup.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListLookupRequest());
                return Results.Ok(result.Value);
            });

        lookup.MapPut("{id}",  async (IMediator mediator, long id, UpdateLookupRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
