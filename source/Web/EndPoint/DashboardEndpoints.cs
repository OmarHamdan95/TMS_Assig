namespace AjKpi.Web;

public static class DashboardEndpoints
{
    public static void RegisterDashboardEndpoints(this IEndpointRouteBuilder routes)
    {
        var dashboard = routes.MapGroup("/api/dashboard").RequireAuthorization().WithTags(nameof(DashboardEndpoints));

        dashboard.MapGet("CountActive",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountActiveDashboardRequest());
                return Results.Ok(result.Value);
            });

        dashboard.MapGet("CountKpiTasks",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountKpiTaskDashboardRequest());
                return Results.Ok(result.Value);
            });


        dashboard.MapGet("CountWfStageByStep/{stepCode}",
            async (IMediator mediator, string? stepCode) =>
            {
                var result = await mediator.Send(new CountWfStageByStepDashboardRequest(stepCode));
                return Results.Ok(result.Value);
            });


        dashboard.MapGet("CountDraftKpi",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountDraftDashboardRequest());
                return Results.Ok(result.Value);
            });

        dashboard.MapGet("CountMyTask",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountMyTaskDashboardRequest());
                return Results.Ok(result.Value);
            });

        dashboard.MapGet("CountTask",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountActiveTaskDashboardRequest());
                return Results.Ok(result.Value);
            });

        dashboard.MapGet("CountDoneTask",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountDoneTaskDashboardRequest());
                return Results.Ok(result.Value);
            });

        dashboard.MapGet("CountDelayedTask",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new CountDelayedTaskDashboardRequest());
                return Results.Ok(result.Value);
            });


        dashboard.MapPost("CountKpiByDepartment",
            async (IMediator mediator , CountKpiByDepDashboardRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        dashboard.MapPost("KpiResult",
            async (IMediator mediator , KpiTaskResultDashboardRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });


        dashboard.MapGet("KpiRequestByStep",
            async (IMediator mediator ) =>
            {
                var result = await mediator.Send(new RequestByStepDashboardRequest());
                return Results.Ok(result.Value);
            });


        //users.MapPost("", (AddAttachmenRequest request) => Mediator.Send(request).ApiResult());
    }
}
