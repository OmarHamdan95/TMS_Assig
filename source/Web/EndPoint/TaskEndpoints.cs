using TMS.Application;
using TMS.Domain;
using TaskStatus = TMS.Domain.TaskStatus;
namespace TMS.Web;

public static class TaskEndpoints
{
    public static void RegisterTaskEndpoints(this IEndpointRouteBuilder routes)
    {
        var task = routes.MapGroup("/api/tasks").RequireAuthorization().WithTags(nameof(TaskEndpoints));


        task.MapPost("",
            [Authorize(Policy = "MUser")] async (IMediator mediator, AddTaskRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        task.MapGet("{id}", async (IMediator mediator, long id) =>
        {
            var result = await mediator.Send(new GetTaskRequest(id));
            return Results.Ok(result.Value);
        });
        //
        task.MapDelete("{id}",
            [Authorize(Policy = "MUser")] async (IMediator mediator, long id) =>
            {
                var result = await mediator.Send(new DeleteTaskRequest(id));
                return Results.Ok(result);
            });
        task.MapPost("grid",
            async (IMediator mediator, [FromBody] GridTaskRequest request) =>
            {
                var result = await mediator.Send(request);
                return Results.Ok(result.Value);
            });

        task.MapGet("list",
            async (IMediator mediator) =>
            {
                var result = await mediator.Send(new ListTaskRequest());
                return Results.Ok(result.Value);
            });


        task.MapGet("GetTaskByStatus",
            async (TaskStatus status, IMediator mediator) =>
            {
                var result = await mediator.Send(new GetTaskByStatusRequest(status));
                return Results.Ok(result.Value);
            });

        task.MapGet("GetTaskDueDate",
            async ( IMediator mediator) =>
            {
                var result = await mediator.Send(new GetTaskDueDateRequest());
                return Results.Ok(result.Value);
            });

        task.MapGet("GetUserTaskCountTask",  [Authorize(Policy = "MUser")]
            async ( IMediator mediator) =>
            {
                var result = await mediator.Send(new GetUserTaskCountTaskRequest());
                return Results.Ok(result.Value);
            });


        task.MapPut("{id}", async (IMediator mediator, long id, UpdateTaskRequest request) =>
        {
            request.Id = id;
            var result = await mediator.Send(request);
            return Results.Ok(result);
        });


        task.MapGet("search",
            async (TaskStatus? status, TaskPriority? priority, DateTime? dueDate, string? orderBy, int pageIndex, int pageSize, IMediator mediator) =>
            {
                var result = await mediator.Send(new SearchTaskRequest(status, priority, dueDate, orderBy, pageIndex, pageSize));
                return Results.Ok(result.Value);
            });

    }
}
