using System.Text.Json.Serialization;
using AjKpi.Model;

namespace AjKpi.Application;

public sealed record UpdateTaskListResultKpiRequest() : IRequest<Result>
{
    public List<KpiTaskListResult> Items { get; set; }

    public decimal? Result { get; set; }
    public decimal? Percent { get; set; }

}
