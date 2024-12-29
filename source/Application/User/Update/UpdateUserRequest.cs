using System.Text.Json.Serialization;
namespace AjKpi.Application;

public sealed record UpdateUserRequest(string NameAr , string NameEn , string MobileNumber, string Email , long? DepartmentId , long? RoleId) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
