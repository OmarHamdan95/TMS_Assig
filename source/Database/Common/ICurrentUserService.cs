namespace AjKpi.Application.Common;

public interface ICurrentUserService
{
    static ICurrentUserService NoCurrentService { get; }
    string? UserName { get; }
    string? UserId { get; }
    string? DepartmentId { get; }
    string? DepartmentCode { get; }
    string? RoleId { get; }
    string? RoleCode { get; }
    List<string> Permissions { get; }
}
