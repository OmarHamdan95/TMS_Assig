namespace AjKpi.Application;

public sealed class DeleteSystemMenuRequestValidator : AbstractValidator<DeleteSystemMenuRequest>
{
    public DeleteSystemMenuRequestValidator() => RuleFor(request => request.Id).Id();
}
