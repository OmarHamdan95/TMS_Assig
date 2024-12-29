namespace AjKpi.Application;

public sealed class GridKpiActiveResultListRequestValidator : AbstractValidator<GridKpiActiveResultListRequest>
{
    public GridKpiActiveResultListRequestValidator() => RuleFor(request => request).Grid();
}
