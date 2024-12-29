namespace AjKpi.Web;

public static class RoleEndpoints
{
    public static void RegisterRoleEndpoints(this IEndpointRouteBuilder routes)
    {
        var user = routes.MapGroup("/api/role").RequireAuthorization().WithTags(nameof(RoleEndpoints));


        user.MapPost("",
            async (IMediator mediator, AddRoleRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        user.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetRoleRequest(id));
            return Results.Ok(result.Value);
        });

        user.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteRoleRequest(id));
                return Results.Ok(result);
            });

        user.MapPost("grid",
            async (IMediator mediator, [FromBody]GridRoleRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        user.MapPatch("{id}/inactivate",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new InactivateRoleRequest(id));
                return Results.Ok(result);
            });

        user.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListRoleRequest());
                return Results.Ok(result.Value);
            });

        user.MapPut("{id}",  async (IMediator mediator, long id, UpdateRoleRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
