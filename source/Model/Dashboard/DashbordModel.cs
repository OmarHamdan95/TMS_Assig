namespace AjKpi.Model.Dashboard;

public class DashbordMyTaskModel
{
    public long? Active { get; set; }
    public long? Completed { get; set; }
}

public class DashbordTaskModel
{
    public long? Active { get; set; }
    public long? Count { get; set; }
}

public class DashbordDoneTaskModel
{
    public long? Completed { get; set; }
    public long? Count { get; set; }
}

public class DashbordDelayedModel
{
    public long? Delayed { get; set; }
    public long? Count { get; set; }
}


public class DashbordKpiByDepModel
{
    public long? DepartmentID { get; set; }
    public string? DepartmentName { get; set; }
    public long? Count { get; set; }
}


public class DashbordKpiTaskResultModel
{
    public decimal? Result { get; set; }
    public decimal? Target { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
}

public class DashbordRequestByStepModel
{
    public string? StepName { get; set; }
    public long? Count { get; set; }
}
