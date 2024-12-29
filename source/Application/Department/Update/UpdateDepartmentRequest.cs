using System.Text.Json.Serialization;
using AjKpi.Model;

namespace AjKpi.Application;

public sealed record UpdateDepartmentRequest(string? NameAr, string? NameEn ) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
