using System.Text.Json.Serialization;
namespace TMS.Application;

public sealed record UpdateUserRequest(string NameAr , string NameEn , string MobileNumber, string Email , long? DepartmentId , UserRole? Role) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
