namespace AjKpi.Application;

public sealed class AddDepartmentRequestValidator :  AbstractValidator<AddDepartmentRequest>
{
    public AddDepartmentRequestValidator()
    {
        RuleFor(request => request.Code).Name();
        RuleFor(request => request.NameAr).NotEmpty();
        RuleFor(request => request.NameEn).NotEmpty();
    }
}
