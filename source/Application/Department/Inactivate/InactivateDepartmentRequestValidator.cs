namespace AjKpi.Application;

public sealed class InactivateDepartmentRequestValidator : AbstractValidator<InactivateDepartmentRequest>
{
    public InactivateDepartmentRequestValidator() => RuleFor(request => request.Id).Id();
}
