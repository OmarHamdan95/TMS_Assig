namespace AjKpi.Application;

public sealed class GridRequestValidator : AbstractValidator<GridRequest>
{
    public GridRequestValidator() => RuleFor(request => request).Grid();
}
