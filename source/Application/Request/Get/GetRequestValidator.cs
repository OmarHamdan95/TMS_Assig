namespace AjKpi.Application;

public sealed class GetRequestValidator : AbstractValidator<GetRequest>
{
    public GetRequestValidator() => RuleFor(request => request.Id).Id();
}
