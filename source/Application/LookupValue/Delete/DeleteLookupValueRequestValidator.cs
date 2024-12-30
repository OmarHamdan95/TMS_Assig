namespace TMS.Application;

public sealed class DeleteLookupValueRequestValidator : AbstractValidator<DeleteLookupValueRequest>
{
    public DeleteLookupValueRequestValidator() => RuleFor(request => request.Id).Id();
}
