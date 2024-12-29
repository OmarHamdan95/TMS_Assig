using AjKpi.Domain;

namespace AjKpi.Model;

public sealed record UserModel
{
    public long Id { get; init; }

    public string? UserName { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
    public string? MobileNumber { get; init; }

    public string? Email { get; init; }
    public Status Status { get; init; }

    public LookupValueModel Department { get; init; }

    public long? DepartmentId { get; init; }
    public LookupValueModel Role { get; init; }
    public long? RoleId { get; init; }

}
