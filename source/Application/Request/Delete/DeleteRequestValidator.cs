namespace AjKpi.Application;

public sealed class DeleteRequestValidator : AbstractValidator<DeleteRequest>
{
    public DeleteRequestValidator() => RuleFor(request => request.Id).Id();
}
