namespace AjKpi.Application;

public sealed class GetDepartmentRequestValidator : AbstractValidator<GetDepartmentRequest>
{
    public GetDepartmentRequestValidator() => RuleFor(request => request.Id).Id();
}
