namespace AjKpi.Application;

public sealed class GridPermissionRequestValidator : AbstractValidator<GridPermissionRequest>
{
    public GridPermissionRequestValidator() => RuleFor(request => request).Grid();
}
