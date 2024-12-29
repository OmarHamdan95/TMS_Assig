using AjKpi.Domain;
using AjKpi.Model;

namespace AjKpi.Model;

public class KpiModel
{
    public long? Id { get; set; }
    public string? Number { get; set; }
    public RequestTypeModel? Type { get; set; }
    public long? TypeId { get; set; }
    public LookupValueModel? KpiType { get; set; }
    public long? KpiTypeId { get; set; }

    public LookupValueModel? MeasurementUnit { get; set; }
    public long? MeasurementUnitId { get; set; }
    public LookupValueModel? MathematicalEquationAb { get; set; }
    public long? MathematicalEquationAbId { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public LookupValueModel? MeasurementCycle { get; set; }
    public long? MeasurementCycleId { get; set; }
    public string? DescriptionAAr { get; set; }
    public string? DescriptionAEn { get; set; }
    public string? DescriptionBAr { get; set; }
    public string? DescriptionBEn { get; set; }
    public LookupValueModel? IndicatorModularity { get; set; }
    public long? IndicatorModularityId { get; set; }
    public bool? IsPrivet { get; set; }
    public bool? StatisticalIndicator { get; set; }
    public LookupValueModel? IndexCreationRate { get; set; }
    public long? IndexCreationRateId { get; set; }
    public LookupValueModel? IndexSource { get; set; }
    public long? IndexSourceId { get; set; }
    public LookupValueModel? IndexClass { get; set; }
    public long? IndexClassId { get; set; }
    public LookupValueModel? BalancedScored { get; set; }
    public long? BalancedScoredId { get; set; }
    public LookupValueModel? RelatedStratigicGoal { get; set; }
    public long? RelatedStratigicGoalId { get; set; }
    public LookupValueModel? FirstResultSource { get; set; }
    public long? FirstResultSourceId { get; set; }
    public string? FirstResult { get; set; }

    public string? FirstResultDetails { get; set; }

    //public List<LookupValue?> OrgUnit { get; set; }
    public LookupValueModel? OwnerDepartemnt { get; set; }

    public long? OwnerDepartemntId { get; set; }

    //public List<LookupValue?> Operation { get; set; }
    public LookupValueModel? OperationAction { get; set; }
    public long? OperationActionId { get; set; }
    public RequestResultModel Reqeust { get; set; }
    public long ReqeustId { get; set; }
    public LookupValueModel? Status { get; set; }
    public long? StatusId { get; set; }


    public long? InputMethodId { get; set; }
    public LookupValue? InputMethod { get; set; }
    public long? AggregateCoefficientValuesMethodAId { get; set; }
    public LookupValue? AggregateCoefficientValuesMethodA { get; set; }
    public long? AggregateCoefficientValuesMethodBId { get; set; }

    public LookupValue? AggregateCoefficientValuesMethodB { get; set; }
}

public class KpiGridModel
{
    public long? Id { get; set; }
    public string? Number { get; set; }
    public LookupValueModel? Type { get; set; }
    public long? TypeId { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public LookupValueModel? OwnerDepartemnt { get; set; }
    public LookupValueModel? MeasurementCycle { get; set; }
    public long? MeasurementCycleId { get; set; }
    public long? OwnerDepartemntId { get; set; }
    public LookupValueModel? Status { get; set; }
    public long? StatusId { get; set; }
    public long? RequestId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public DateTime? CreatedDate { get; set; }
    public LookupValueModel? KpiType { get; set; }
    public long? KpiTypeId { get; set; }
}

public class KpiResultModel
{
    public long? Id { get; set; }
    public string? Number { get; set; }
    public LookupValueModel? Type { get; set; }
    public LookupValueModel? KpiType { get; set; }
    public long? TypeId { get; set; }
    public long? InputMethodId { get; set; }
    public long? AggregateCoefficientValuesMethodAId { get; set; }
    public long? AggregateCoefficientValuesMethodBId { get; set; }
    public long? KpiTypeId { get; set; }
    public LookupValueModel? MeasurementUnit { get; set; }
    public long? MeasurementUnitId { get; set; }
    public LookupValueModel? MathematicalEquationAb { get; set; }
    public long? MathematicalEquationAbId { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public LookupValueModel? MeasurementCycle { get; set; }
    public long? MeasurementCycleId { get; set; }
    public string? DescriptionAAr { get; set; }
    public string? DescriptionAEn { get; set; }
    public string? DescriptionBAr { get; set; }
    public string? DescriptionBEn { get; set; }
    public LookupValueModel? IndicatorModularity { get; set; }
    public long? IndicatorModularityId { get; set; }
    public bool? IsPrivet { get; set; }
    public bool? StatisticalIndicator { get; set; }
    public LookupValueModel? IndexCreationRate { get; set; }
    public long? IndexCreationRateId { get; set; }
    public LookupValueModel? IndexSource { get; set; }
    public long? IndexSourceId { get; set; }
    public LookupValueModel? IndexClass { get; set; }
    public long? IndexClassId { get; set; }
    public LookupValueModel? BalancedScored { get; set; }
    public long? BalancedScoredId { get; set; }
    public LookupValueModel? RelatedStratigicGoal { get; set; }
    public long? RelatedStratigicGoalId { get; set; }
    public LookupValueModel? FirstResultSource { get; set; }
    public long? FirstResultSourceId { get; set; }
    public string? FirstResult { get; set; }

    public string? FirstResultDetails { get; set; }

    //public List<LookupValue?> OrgUnit { get; set; }
    public LookupValueModel? OwnerDepartemnt { get; set; }

    public long? OwnerDepartemntId { get; set; }

    //public List<LookupValue?> Operation { get; set; }
    public LookupValueModel? OperationAction { get; set; }
    public long? OperationActionId { get; set; }
    public long? ReqeustId { get; set; }
    public LookupValueModel? Status { get; set; }
    public long? StatusId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? PoliticsId { get; set; }
    public LookupValueModel? Politics { get; set; }
    public long? QualityOfLifeId { get; set; }
    public LookupValueModel? QualityOfLife { get; set; }
    public long? RiskId { get; set; }
    public LookupValueModel? Risk { get; set; }
    public long? SustainableDevelopmentGoalId { get; set; }
    public LookupValueModel? SustainableDevelopmentGoal { get; set; }
    public long? PolarityId { get; set; }
    public LookupValueModel? Polarity { get; set; }
}

public class KpiTaskListResult
{
    public long? Id { get; set; }
    public long? KpiId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public long? AValue { get; set; }
    public long? BValue { get; set; }
    public decimal? ResultValue { get; set; }
    public long? Target { get; set; }
    public decimal? VerificationRate { get; set; }
    public bool? IsLocked { get; set; }
}
