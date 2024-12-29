namespace AjKpi.Application;

public sealed class DeleteAttachmenRequestValidator : AbstractValidator<DeleteAttachmenRequest>
{
    public DeleteAttachmenRequestValidator() => RuleFor(request => request.Id).Id();
}
