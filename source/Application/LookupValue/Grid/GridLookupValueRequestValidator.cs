namespace TMS.Application;

public sealed class GridLookupValueRequestValidator : AbstractValidator<GridLookupValueRequest>
{
    public GridLookupValueRequestValidator() => RuleFor(request => request).Grid();
}
