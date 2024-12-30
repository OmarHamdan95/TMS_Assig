using TMS.Application;
namespace TMS.Web;

public static class UserEndpoints
{
    public static void RegisterUserEndpoints(this IEndpointRouteBuilder routes)
    {
        var user = routes.MapGroup("/api/users").RequireAuthorization().WithTags(nameof(UserEndpoints));


        user.MapPost("",
            [Authorize(Policy = "MUser")]  async (IMediator mediator, AddUserRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        user.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetUserRequest(id));
            return Results.Ok(result.Value);
        });

        user.MapDelete("{id}",
            [Authorize(Policy = "MUser")] async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteUserRequest(id));
                return Results.Ok(result);
            });

        user.MapPost("grid",
            async (IMediator mediator, [FromBody]GridUserRequest request) =>
            {
                var result = await mediator.Send(request);
                return  Results.Ok(result.Value);
            });

        user.MapPatch("{id}/inactivate",
            [Authorize(Policy = "MUser")]  async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new InactivateUserRequest(id));
                return Results.Ok(result);
            });

        user.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListUserRequest());
                return Results.Ok(result.Value);
            });

        user.MapPut("{id}", [Authorize(Policy = "MUser")]  async (IMediator mediator, long id, UpdateUserRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });

        user.MapPut("changePassword", async (IMediator mediator,  ChangePasswordRequest request) =>
        {
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });
    }
}
