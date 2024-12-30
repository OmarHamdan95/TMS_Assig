namespace TMS.Application;

public sealed class GetUserRequestValidator : AbstractValidator<GetUserRequest>
{
    public GetUserRequestValidator() => RuleFor(request => request.Id).Id();
}
