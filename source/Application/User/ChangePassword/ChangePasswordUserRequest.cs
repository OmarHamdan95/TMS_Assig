
namespace AjKpi.Application;

public sealed record ChangePasswordRequest(long? Id  , string? OldPassword , string? NewPassword , string? ConfirmPassword) : IRequest<Result>
{

}
