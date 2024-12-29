namespace AjKpi.Application;

public sealed record AddKpiRequest() : IRequest<Result<long>>
{
    public string? Code { get; set; }
    public long? Id { get; set; }
    public string? Number { get; set; }
    public long? TypeId { get; set; }
    public long? KpiTypeId { get; set; }
    public long? MeasurementUnitId { get; set; }
    public long? MathematicalEquationAbId { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public long? MeasurementCycleId { get; set; }
    public string? DescriptionAAr { get; set; }
    public string? DescriptionAEn { get; set; }
    public string? DescriptionBAr { get; set; }
    public string? DescriptionBEn { get; set; }
    public long? IndicatorModularityId { get; set; }
    public bool? IsPrivet { get; set; }
    public bool? StatisticalIndicator { get; set; }
    public long? IndexCreationRateId { get; set; }
    public long? IndexSourceId { get; set; }
    public long? IndexClassId { get; set; }
    public long? BalancedScoredId { get; set; }
    public long? RelatedStratigicGoalId { get; set; }
    public long? FirstResultSourceId { get; set; }
    public long? FirstResult { get; set; }
    public string? FirstResultDetails { get; set; }
    public long? OperationActionId { get; set; }
    public long ReqeustId { get; set; }
    public long? StatusId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? InputMethodId { get; set; }
    public long? AggregateCoefficientValuesMethodAId { get; set; }
    public long? AggregateCoefficientValuesMethodBId { get; set; }

    public string? InitiaterNotes { get; set; }

    public long? PoliticsId { get; set; }

    public long? QualityOfLifeId { get; set; }

    public long? RiskId { get; set; }

    public long? SustainableDevelopmentGoalsId { get; set; }
    public long? PolarityId { get; set; }

    public long? DepartmentId { get; set; }
    public long? ParentKpiId { get; set; }

}
