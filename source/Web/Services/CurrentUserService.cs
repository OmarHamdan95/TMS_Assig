using MoreLinq;
using TMS.Application.Common;

namespace TMS.Web.Services;

public class CurrentUserService : ICurrentUserService
{
    public static ICurrentUserService NoCurrentService => new CurrentUserService(new HttpContextAccessor());

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public string? UserName => GetClaimValue("UserName");
    public string? UserId => GetClaimValue("UserId");
    public string? Role => GetClaimValue("Role");


    private string GetClaimValue(string claim) =>
        _httpContextAccessor?.HttpContext?.User?.Claims?.FirstOrDefault(x => x.Type == claim)?.Value ?? "";

    private List<string> GetClaimValues(string claim) =>  _httpContextAccessor?.HttpContext?.User?.Claims?.Where(x => x.Type == claim)
        .FirstOrDefault()
        ?.Value.Split(',').ToList() ?? new List<string>();
}
