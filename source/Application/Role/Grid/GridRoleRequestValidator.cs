namespace AjKpi.Application;

public sealed class GridRoleRequestValidator : AbstractValidator<GridRoleRequest>
{
    public GridRoleRequestValidator() => RuleFor(request => request).Grid();
}
