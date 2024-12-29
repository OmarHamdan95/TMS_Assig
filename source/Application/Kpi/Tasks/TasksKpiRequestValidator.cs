namespace AjKpi.Application;

public sealed class TaskKpiRequestValidator : AbstractValidator<TaskKpiRequest>
{
    public TaskKpiRequestValidator() => RuleFor(request => request).Grid();
}
