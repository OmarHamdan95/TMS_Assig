namespace AjKpi.Domain;

public class Kpi : BaseAuditableEntity, IAggregateRoot
{
    public string? Number { get; set; }
    public RequestType? Type { get; set; }
    public long? TypeId { get; set; }
    public LookupValue? KpiType { get; set; }
    public long? KpiTypeId { get; set; }
    public LookupValue? MeasurementUnit { get; set; }
    public long? MeasurementUnitId { get; set; }
    public LookupValue? MathematicalEquationAb { get; set; }
    public long? MathematicalEquationAbId { get; set; }
    public string? NameAr { get; set; }
    public string? NameEn { get; set; }
    public string? DescriptionAr { get; set; }
    public string? DescriptionEn { get; set; }
    public LookupValue? MeasurementCycle { get; set; }
    public long? MeasurementCycleId { get; set; }
    public string? DescriptionAAr { get; set; }
    public string? DescriptionAEn { get; set; }
    public string? DescriptionBAr { get; set; }
    public string? DescriptionBEn { get; set; }
    public LookupValue? IndicatorModularity { get; set; }
    public long? IndicatorModularityId { get; set; }
    public bool? IsPrivet { get; set; }
    public bool? StatisticalIndicator { get; set; }
    public LookupValue? IndexCreationRate { get; set; }
    public long? IndexCreationRateId { get; set; }
    public LookupValue? IndexSource { get; set; }
    public long? IndexSourceId { get; set; }
    public LookupValue? IndexClass { get; set; }
    public long? IndexClassId { get; set; }
    public LookupValue? BalancedScored { get; set; }
    public long? BalancedScoredId { get; set; }
    public LookupValue? RelatedStratigicGoal { get; set; }
    public long? RelatedStratigicGoalId { get; set; }
    public LookupValue? FirstResultSource { get; set; }
    public long? FirstResultSourceId { get; set; }
    public decimal? FirstResult { get; set; }
    public decimal? Percantage { get; set; }
    public string? FirstResultDetails { get; set; }
    //public List<LookupValue?> OrgUnit { get; set; }
    public Department? OwnerDepartemnt { get; set; }
    public long? OwnerDepartemntId { get; set; }
    //public List<LookupValue?> Operation { get; set; }
    public LookupValue? OperationAction { get; set; }
    public long? OperationActionId { get; set; }

    public long? RequestId { get; set; }
    public Request Reqeust { get; set; }

    public LookupValue? Status { get; set; }
    public long? StatusId { get; set; }

    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }

    public long? InputMethodId { get; set; }
    public LookupValue? InputMethod { get; set; }
    public long? AggregateCoefficientValuesMethodAId { get; set; }
    public LookupValue? AggregateCoefficientValuesMethodA { get; set; }
    public long? AggregateCoefficientValuesMethodBId { get; set; }

    public LookupValue? AggregateCoefficientValuesMethodB { get; set; }

    public long? PoliticsId { get; set; }
    public LookupValue? Politics { get; set; }

    public LookupValue? QualityOfLife { get; set; }
    public long? QualityOfLifeId { get; set; }

    public LookupValue? Risk { get; set; }
    public long? RiskId { get; set; }

    public LookupValue? SustainableDevelopmentGoal { get; set; }
    public long? SustainableDevelopmentGoalId { get; set; }

    public LookupValue? Polarity { get; set; }
    public long? PolarityId { get; set; }

    public Kpi ParentKpi {get;set;}
    public long? ParentKpiId { get; set; }

    public List<KpiTask> KpiTasks { get; set; }

    public Kpi(string? code, string? number, long? typeId, long? kpiTypeId, long? measurementUnitId, long? mathematicalEquationAbId, string? nameAr,
        string? nameEn, string? descriptionAr, string? descriptionEn, long? measurementCycleId, string? descriptionAAr, string? descriptionAEn, string? descriptionBAr, string? descriptionBEn,
        long? indicatorModularityId, bool? isPrivet, bool? statisticalIndicator, long? indexCreationRateId, long? indexSourceId, long? indexClassId, long? balancedScoredId, long? relatedStratigicGoalId,
        long? firstResultSourceId, decimal? firstResult, string firstResultDetails, long? ownerDepartemntId, long? operationActionId, long? statusId, DateTime? startDate, DateTime? endDate,
        long? inputMethodId, long? aggregateCoefficientValuesMethodAId, long? aggregateCoefficientValuesMethodBId,
        long? politicsId , long? qualityOfLifeId, long? riskId , long? sustainableDevelopmentGoalId , long? polarityId , long? parentKpiId)
    {
        Code = code;
        Number = number;
        TypeId = typeId;
        MeasurementUnitId = measurementUnitId;
        MathematicalEquationAbId = mathematicalEquationAbId;
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        MeasurementCycleId = measurementCycleId;
        DescriptionAAr = descriptionAAr;
        DescriptionAEn = descriptionAEn;
        DescriptionBAr = descriptionBAr;
        DescriptionBEn = descriptionBEn;
        IndicatorModularityId = indicatorModularityId;
        IsPrivet = isPrivet;
        StatisticalIndicator = statisticalIndicator;
        IndexCreationRateId = indexCreationRateId;
        IndexSourceId = indexSourceId;
        IndexClassId = indexClassId;
        BalancedScoredId = balancedScoredId;
        RelatedStratigicGoalId = relatedStratigicGoalId;
        FirstResultSourceId = firstResultSourceId;
        FirstResult = firstResult;
        FirstResultDetails = firstResultDetails;
        OwnerDepartemntId = ownerDepartemntId;
        OperationActionId = operationActionId;
        StatusId = statusId;
        StartDate = startDate;
        EndDate = endDate;
        InputMethodId = inputMethodId;
        AggregateCoefficientValuesMethodAId = aggregateCoefficientValuesMethodAId;
        AggregateCoefficientValuesMethodBId = aggregateCoefficientValuesMethodBId;
        KpiTypeId = kpiTypeId;
        PoliticsId = politicsId;
        QualityOfLifeId = qualityOfLifeId;
        RiskId = riskId;
        SustainableDevelopmentGoalId = sustainableDevelopmentGoalId;
        PolarityId = polarityId;
        ParentKpiId = parentKpiId;
    }

    public Kpi() { }

    public void SetReqeust(long? reqeustId) => RequestId = reqeustId;

    public void UpdateStats(long? stautsId) => StatusId = stautsId;

    public void Update(long? typeId, long? measurementUnitId, long? mathematicalEquationAbId, string? nameAr,
        string? nameEn, string? descriptionAr, string? descriptionEn, long? measurementCycleId, string? descriptionAAr,
        string? descriptionAEn, string? descriptionBAr, string? descriptionBEn,
        long? indicatorModularityId, bool? isPrivet, bool? statisticalIndicator, long? indexCreationRateId,
        long? indexSourceId, long? indexClassId, long? balancedScoredId, long? relatedStratigicGoalId,
        long? firstResultSourceId, decimal? firstResult, string firstResultDetails, long? ownerDepartemntId,
        long? operationActionId, DateTime? startDate, DateTime? endDate,
        long? inputMethodId, long? aggregateCoefficientValuesMethodAId, long? aggregateCoefficientValuesMethodBId, long? kpiTypeId ,
        long? politicsId , long? qualityOfLifeId, long? riskId , long? sustainableDevelopmentGoalId , long? polarityId , long? parentKpiId)
    {
        TypeId = typeId;
        MeasurementUnitId = measurementUnitId;
        MathematicalEquationAbId = mathematicalEquationAbId;
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        MeasurementCycleId = measurementCycleId;
        DescriptionAAr = descriptionAAr;
        DescriptionAEn = descriptionAEn;
        DescriptionBAr = descriptionBAr;
        DescriptionBEn = descriptionBEn;
        IndicatorModularityId = indicatorModularityId;
        IsPrivet = isPrivet;
        StatisticalIndicator = statisticalIndicator;
        IndexCreationRateId = indexCreationRateId;
        IndexSourceId = indexSourceId;
        IndexClassId = indexClassId;
        BalancedScoredId = balancedScoredId;
        RelatedStratigicGoalId = relatedStratigicGoalId;
        FirstResultSourceId = firstResultSourceId;
        FirstResult = firstResult;
        FirstResultDetails = firstResultDetails;
        OwnerDepartemntId = ownerDepartemntId;
        OperationActionId = operationActionId;
        StartDate = startDate;
        EndDate = endDate;
        InputMethodId = inputMethodId;
        AggregateCoefficientValuesMethodAId = aggregateCoefficientValuesMethodAId;
        AggregateCoefficientValuesMethodBId = aggregateCoefficientValuesMethodBId;
        KpiTypeId = kpiTypeId;
        PoliticsId = politicsId;
        QualityOfLifeId = qualityOfLifeId;
        RiskId = riskId;
        SustainableDevelopmentGoalId = sustainableDevelopmentGoalId;
        PolarityId = polarityId;
        ParentKpiId = parentKpiId;
    }

    public void SetNumber(string? number) => Number = number;

    public void SetResult(decimal? resultValue, decimal? percantage)
    {
        FirstResult = resultValue;
        Percantage = percantage;
    }

    //public void SetRequestId(long? reqeustId) => RequestId = reqeustId;

}
