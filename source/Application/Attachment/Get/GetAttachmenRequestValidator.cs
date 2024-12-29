namespace AjKpi.Application;

public sealed class GetAttachmenRequestValidator : AbstractValidator<GetAttachmenRequest>
{
    public GetAttachmenRequestValidator() => RuleFor(request => request.Id).Id();
}
