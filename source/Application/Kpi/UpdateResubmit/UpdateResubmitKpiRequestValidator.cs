namespace AjKpi.Application;

public sealed class UpdateResubmitKpiRequestValidator :  AbstractValidator<UpdateResubmitKpiRequest>
{
    public UpdateResubmitKpiRequestValidator()
    {
        RuleFor(request => request.Item.NameEn).NotEmpty();
        RuleFor(request => request.Item.NameEn).NotEmpty();
    }
}
