namespace AjKpi.Application;

public sealed class GridWfTransactionReqeustValidator : AbstractValidator<GridWfTransactionReqeust>
{
    public GridWfTransactionReqeustValidator() => RuleFor(request => request).Grid();
}
