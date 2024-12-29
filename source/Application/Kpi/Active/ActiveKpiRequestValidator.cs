namespace AjKpi.Application;

public sealed class ActiveKpiRequestValidator : AbstractValidator<ActiveKpiRequest>
{
    public ActiveKpiRequestValidator() => RuleFor(request => request).Grid();
}
