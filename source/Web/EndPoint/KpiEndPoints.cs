using AjKpi.Web.Handler.Authorization;

namespace AjKpi.Web;

public static class KpiEndPoints
{
    public static void RegisterKpiEndpoints(this IEndpointRouteBuilder routes)
    {
        var kpi = routes.MapGroup("/api/kpi").RequireAuthorization().WithTags(nameof(KpiEndPoints));

        kpi.MapPost("",
            [Authorize(Policy = "CreateKpi")] async (IMediator mediator, AddKpiRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        kpi.MapPost("Submit/{id?}",
            [Authorize(Policy = "CreateKpi")] async (IMediator mediator, long? Id) =>
            {
                var result = await mediator.Send(new SubmitKpiReqeust(Id));
                return Results.Ok(result);
            });


        kpi.MapGet("{id}",  async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetKpiRequest(id));
            return Results.Ok(result.Value);
        });

        kpi.MapDelete("{id}",
            async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteKpiRequest(id));
                return Results.Ok(result);
            });

        kpi.MapPost("grid",
            async (IMediator mediator, [FromBody] GridKpiRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        kpi.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListKpiRequest());
                return Results.Ok(result.Value);
            });

        kpi.MapPost("tasks",
            async (IMediator mediator, [FromBody] TaskKpiRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        kpi.MapPost("active-list",
           async (IMediator mediator, [FromBody] ActiveKpiRequest request) =>
           {
               var result = await mediator.Send(request);
               return Results.Ok(result.Value);
           });


        kpi.MapPost("fill-active-list",
            async (IMediator mediator, [FromBody] GridKpiActiveResultListRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        kpi.MapPost("gridTaskListResult",
            async (IMediator mediator, [FromBody] GridKpiTaskListResultRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        kpi.MapPut("update-resubmit",
            async (IMediator mediator, [FromBody] UpdateResubmitKpiRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result);
            });

        kpi.MapPut("update",
            async (IMediator mediator, [FromBody] UpdateKpiRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result);
            });


        kpi.MapPut("saveResult",
            async (IMediator mediator, [FromBody] UpdateTaskListResultKpiRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result);
            });
    }
}
