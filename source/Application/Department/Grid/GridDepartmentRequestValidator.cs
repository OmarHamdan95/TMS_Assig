namespace AjKpi.Application;

public sealed class GridDepartmentRequestValidator : AbstractValidator<GridDepartmentRequest>
{
    public GridDepartmentRequestValidator() => RuleFor(request => request).Grid();
}
