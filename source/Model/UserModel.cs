using TMS.Domain;

namespace TMS.Model;

public sealed record UserModel
{
    public long Id { get; init; }

    public string? UserName { get; init; }
    public string? NameAr { get; init; }
    public string? NameEn { get; init; }
    public string? MobileNumber { get; init; }

    public string? Email { get; init; }
    public Status Status { get; init; }
    public UserRole? Role { get; init; }

}
