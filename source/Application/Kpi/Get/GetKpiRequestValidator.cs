namespace AjKpi.Application;

public sealed class GetKpiRequestValidator : AbstractValidator<GetKpiRequest>
{
    public GetKpiRequestValidator() => RuleFor(request => request.Id).Id();
}
