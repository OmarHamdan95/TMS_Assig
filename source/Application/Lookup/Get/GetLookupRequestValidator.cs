namespace AjKpi.Application;

public sealed class GetLookupRequestValidator : AbstractValidator<GetLookupRequest>
{
    public GetLookupRequestValidator() => RuleFor(request => request.Id).Id();
}
