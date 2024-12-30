namespace TMS.Application.Common;

public interface ICurrentUserService
{
    static ICurrentUserService NoCurrentService { get; }
    string? UserName { get; }
    string? UserId { get; }
    string? Role { get; }
}
