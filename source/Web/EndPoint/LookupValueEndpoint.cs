using TMS.Application;

namespace TMS.Web;

public static class LookupValueEndpoint
{
    public static void RegisterLookupValueEndpoints(this IEndpointRouteBuilder routes)
    {
        var lookup = routes.MapGroup("/api/lookup-value").RequireAuthorization().WithTags(nameof(LookupValueEndpoint));


        lookup.MapPost("",
            async (IMediator mediator, AddLookupValueRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        lookup.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetLookupValueRequest(id));
            return Results.Ok(result.Value);
        });

        //lookup.MapGet("autoComplate/{lookupCode}", async (IMediator mediator, string? lookupCode , string? text) =>
        //{
        //    var result = await mediator.Send(new AutoCompleteLookupValueRequest(lookupCode, text));
        //    return Results.Ok(result.Value);
        //});

        lookup.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteLookupValueRequest(id));
                return Results.Ok(result);
            });

        lookup.MapPost("grid",
            async (IMediator mediator, [FromBody]GridLookupValueRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        lookup.MapPatch("{id}/inactivate",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new InactivateLookupValueRequest(id));
                return Results.Ok(result);
            });

        lookup.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListLookupValueRequest());
                return Results.Ok(result.Value);
            });

        lookup.MapPut("{id}",  async (IMediator mediator, long id, UpdateLookupValueRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
