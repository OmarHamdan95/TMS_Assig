namespace AjKpi.Application;

public sealed class UpdateKpiRequestValidator : AbstractValidator<UpdateKpiRequest>
{
    public UpdateKpiRequestValidator()
    {
        RuleFor(request => request.Id).NotEmpty();
    }
}
