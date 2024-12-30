namespace TMS.Application;

public sealed class DeleteUserRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteUserRequestValidator() => RuleFor(request => request.Id).Id();
}
