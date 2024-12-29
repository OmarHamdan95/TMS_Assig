using AjKpi.Domain;

namespace AjKpi.Model;

public sealed record RoleModel
{
    public long Id { get; init; }

    public string? NameAr { get; init; }
    public string? NameEn { get; init; }

    public string? Code { get; init; }
    public LookupValueModel Department { get; init; }

    public long? DepartmentId { get; init; }

    public List<PermissionModel>? Permissions { get; init; }

}
