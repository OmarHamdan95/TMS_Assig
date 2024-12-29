using System.Text.Json.Serialization;
using AjKpi.Model;

namespace AjKpi.Application;

public sealed record UpdateLookupRequest(string? NameAr, string? NameEn ,
    List<LookupValueModel>? LookupValueModels , string? dataType ,  LookupModel? parent) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
