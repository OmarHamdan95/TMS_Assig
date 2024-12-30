using System.Text.Json.Serialization;
using TMS.Model;

namespace TMS.Application;

public sealed record UpdateLookupRequest(string? NameAr, string? NameEn ,
    List<LookupValueModel>? LookupValueModels , string? dataType ,  LookupModel? parent) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
