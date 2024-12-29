
namespace AjKpi.Web;

public static class RequestTypesEndPoints
{
    public static void RegisterRequestTypesEndPoints(this IEndpointRouteBuilder routes)
    {
        var requestType = routes.MapGroup("/api/reqeustType").RequireAuthorization().WithTags(nameof(RequestTypesEndPoints));


        requestType.MapGet("{code?}", async (IMediator mediator, string? code) =>
        {
            var result = await mediator.Send(new GetRequestTypesRequest(code));
            return Results.Ok(result.Value);
        });


        requestType.MapGet("Statuses/{code?}", async (IMediator mediator, string? code) =>
        {
            var result = await mediator.Send(new GetRequestTypeStatusesRequest(code));
            return Results.Ok(result.Value);
        });
    }
}
