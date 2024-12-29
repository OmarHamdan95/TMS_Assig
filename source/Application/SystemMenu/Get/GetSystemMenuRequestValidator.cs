namespace AjKpi.Application;

public sealed class GetSystemMenuRequestValidator : AbstractValidator<GetSystemMenuRequest>
{
    public GetSystemMenuRequestValidator() => RuleFor(request => request.Id).Id();
}
