namespace AjKpi.Model;

public sealed record  PermissionModel
{
    public string? Code { get; set; }
    public long? Id { get; init; }
    public long? RoleId { get; init; }

    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
}

