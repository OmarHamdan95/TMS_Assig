using System.Text.Json.Serialization;
using AjKpi.Model;

namespace AjKpi.Application;

public sealed record UpdateRequest: IRequest<Result>
{
    public long? RequestId { get; set; }
    public string? Status { get; set; }
    public string? ActorRole { get; set; }
    public string? ActorId { get; set; }
    public string? Note { get; set; }
}
