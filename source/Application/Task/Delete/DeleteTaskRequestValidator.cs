namespace TMS.Application;

public sealed class DeleteTaskRequestValidator : AbstractValidator<DeleteUserRequest>
{
    public DeleteTaskRequestValidator() => RuleFor(request => request.Id).Id();
}
