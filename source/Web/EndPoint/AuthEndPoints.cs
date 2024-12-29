using AjKpi.Application;

namespace AjKpi.Web;

public static class AuthEndPoints
{
    public static void RegisterAuthEndPoints(this IEndpointRouteBuilder routes)
    {
        var auth = routes.MapGroup("/api/auths").RequireAuthorization().WithTags(nameof(AuthEndPoints));

        auth.MapPost("",
            [AllowAnonymous] async (IMediator mediator, AuthRequest request) =>
            {
                var result = await mediator.Send(request);
                return result;
            });


    }
}
