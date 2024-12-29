namespace AjKpi.Web;

public static class DepartmentEndpoint
{
    public static void RegisterDepartmentEndpoints(this IEndpointRouteBuilder routes)
    {
        var lookup = routes.MapGroup("/api/department").RequireAuthorization().WithTags(nameof(DepartmentEndpoint));


        lookup.MapPost("",
            async (IMediator mediator, AddDepartmentRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        lookup.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetDepartmentRequest(id));
            return Results.Ok(result.Value);
        });

        lookup.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteDepartmentRequest(id));
                return Results.Ok(result);
            });

        lookup.MapPost("grid",
            async (IMediator mediator, [FromBody] GridDepartmentRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        lookup.MapPatch("{id}/inactivate",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new InactivateDepartmentRequest(id));
                return Results.Ok(result);
            });

        lookup.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListDepartmentRequest());
                return Results.Ok(result.Value);
            });

        lookup.MapPut("{id}",  async (IMediator mediator, long id, UpdateDepartmentRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
