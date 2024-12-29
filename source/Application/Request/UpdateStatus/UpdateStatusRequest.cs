using System.Text.Json.Serialization;
using AjKpi.Model;

namespace AjKpi.Application;

public sealed record UpdateRequestStatus(long? RequestId, ReqeustStatusModel? Status , string? Note) : IRequest<Result>;
