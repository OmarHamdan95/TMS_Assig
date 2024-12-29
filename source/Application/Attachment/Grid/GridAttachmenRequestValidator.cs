namespace AjKpi.Application;

public sealed class GridAttachmenRequestValidator : AbstractValidator<GridAttachmenRequest>
{
    public GridAttachmenRequestValidator() => RuleFor(request => request).Grid();
}
