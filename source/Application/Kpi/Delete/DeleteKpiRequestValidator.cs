namespace AjKpi.Application;

public sealed class DeleteKpiRequestValidator : AbstractValidator<DeleteKpiRequest>
{
    public DeleteKpiRequestValidator() => RuleFor(request => request.Id).Id();
}
