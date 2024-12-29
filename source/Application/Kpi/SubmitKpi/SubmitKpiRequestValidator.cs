namespace AjKpi.Application;

public sealed class SubmitKpiRequestValidator :  AbstractValidator<SubmitKpiReqeust>
{
    public SubmitKpiRequestValidator()
    {
        RuleFor(request => request.KpiId).NotEmpty();
    }
}
