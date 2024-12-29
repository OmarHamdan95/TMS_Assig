using AjKpi.Application.Common;
using Microsoft.IdentityModel.Tokens;
using Polly;
using static System.Net.HttpStatusCode;

namespace AjKpi.Web.Handler.Authorization;


public class PermissionRequirement :  Attribute , IAuthorizationRequirement
{
    public string Permission { get; }

    public PermissionRequirement(string permission)
    {
        Permission = permission;
    }
}

public class PermissionHandler : AuthorizationHandler<PermissionRequirement>
{
    private ICurrentUserService _currentUserService;
    private readonly IStringLocalizer _stringLocalizer;

    public PermissionHandler(ICurrentUserService currentUserService, IStringLocalizer stringLocalizer) =>
        (_currentUserService, _stringLocalizer) = (currentUserService, stringLocalizer);

    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context,
        PermissionRequirement requirement)
    {
        // Get user ID or other identifier from the claims
        var userId = _currentUserService.UserId ?? null;

        if (userId == null)
        {
            return Task.CompletedTask;
        }

        // Fetch user permissions from the database
        var userPermissions = _currentUserService.Permissions.ToList();

        if (userPermissions.IsNullOrEmpty())
            return Task.CompletedTask;

        if (requirement.Permission is not null && userPermissions.Contains(requirement.Permission))
        {
            context.Succeed(requirement);
        }

        return Task.CompletedTask;
    }
}
