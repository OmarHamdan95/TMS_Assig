namespace AjKpi.Domain;

public class KpiTask : BaseAuditableEntity, IAggregateRoot
{
    public Kpi? Kpi { get; set; }
    public long? KpiId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? AValue { get; set; }
    public long? BValue { get; set; }
    public decimal? ResultValue { get; set; }

    public long? Target { get; set; }
    public decimal? VerificationRate { get; set; }
    public bool? IsLocked { get; set; }


    public KpiTask()
    {

    }

    public KpiTask(long? kpiId, long? aValue, long? bValue, decimal? resultValue, DateTime? startDate, DateTime? endDate , long? target
        , decimal? verificationRate, bool isLocked)
    {
        KpiId = kpiId;
        AValue = aValue;
        BValue = bValue;
        ResultValue = resultValue;
        StartDate = startDate;
        EndDate = endDate;
        Target = target;
        VerificationRate = verificationRate;
        IsLocked = isLocked;
    }

    public KpiTask(long? kpiId, long? aValue, long? bValue, DateTime? startDate, DateTime? endDate)
    {
        KpiId = kpiId;
        AValue = aValue;
        BValue = bValue;
        StartDate = startDate;
        EndDate = endDate;
    }

    public void Calculate(long? aValue, long? bValue, decimal? resultValue , decimal? verificationRate, long? target)
    {
        AValue = aValue;
        BValue = bValue;
        ResultValue = resultValue;
        VerificationRate = verificationRate;
        Target = target;
    }

    public void Locked(bool? isLocked)
    {
        IsLocked = isLocked;
    }
}
