using System.Text.Json.Serialization;
using AjKpi.Model;

namespace AjKpi.Application;

public sealed record UpdateAttachmenRequest(List<AttachmentModel> AttachmentModels) : IRequest<Result>
{
    [JsonIgnore]
    public long Id { get; set; }
}
