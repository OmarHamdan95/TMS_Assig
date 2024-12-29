namespace AjKpi.Application;

public sealed class FillActiveKpiResultRequestValidator : AbstractValidator<GridKpiTaskListResultRequest>
{
    public FillActiveKpiResultRequestValidator() => RuleFor(request => request).Grid();
}
