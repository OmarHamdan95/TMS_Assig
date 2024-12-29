namespace AjKpi.Application;

public sealed class GetLookupValueRequestValidator : AbstractValidator<GetLookupValueRequest>
{
    public GetLookupValueRequestValidator() => RuleFor(request => request.Id).Id();
}
