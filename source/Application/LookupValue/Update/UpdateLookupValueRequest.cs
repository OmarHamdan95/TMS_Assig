using System.Text.Json.Serialization;
using TMS.Model;

namespace TMS.Application;

public sealed record UpdateLookupValueRequest(string? NameAr, string? NameEn ,
    int? LookupId, string? dataType ,  LookupModel? parent) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
