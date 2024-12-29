namespace AjKpi.Application;

public sealed class GridSystemMenuRequestValidator : AbstractValidator<GridSystemMenuRequest>
{
    public GridSystemMenuRequestValidator() => RuleFor(request => request).Grid();
}
