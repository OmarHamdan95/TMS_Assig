using System.Text.Json.Serialization;
namespace AjKpi.Application;

public sealed record UpdateRoleRequest(string NameAr , string NameEn) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
