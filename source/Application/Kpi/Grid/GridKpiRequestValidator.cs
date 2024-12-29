namespace AjKpi.Application;

public sealed class GridKpiRequestValidator : AbstractValidator<GridKpiRequest>
{
    public GridKpiRequestValidator() => RuleFor(request => request).Grid();
}
