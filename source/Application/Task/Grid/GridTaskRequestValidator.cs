namespace TMS.Application;

public sealed class GridTaskRequestValidator : AbstractValidator<GridTaskRequest>
{
    public GridTaskRequestValidator() => RuleFor(request => request).Grid();
}
