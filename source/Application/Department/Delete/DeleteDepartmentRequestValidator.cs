namespace AjKpi.Application;

public sealed class DeleteDepartmentRequestValidator : AbstractValidator<DeleteDepartmentRequest>
{
    public DeleteDepartmentRequestValidator() => RuleFor(request => request.Id).Id();
}
