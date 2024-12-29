namespace AjKpi.Application;

public sealed class AddKpiRequestValidator :  AbstractValidator<AddKpiRequest>
{
    public AddKpiRequestValidator()
    {
        RuleFor(request => request.NameAr).NotEmpty();
        RuleFor(request => request.NameEn).NotEmpty();
    }
}
