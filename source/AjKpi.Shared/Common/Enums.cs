namespace Shared.Common;

public enum KpiStatusEnum
{
    Draft = 35,
    Approved = 36,
    Submit = 37,
    ReSubmitted = 38,
    Rejected = 39,
    InProgress = 40,
    ReturnForUpdate = 41
}

public enum RequestTypeEnum
{
    CreateKPI = 1,
    UpdateKPI = 2
}


public enum MeasurementCycleEnum
{
    Annual,
    Biannual,
    Quarterly,
    Monthly
}

public static class Constant
{
    /// <summary>
    /// For Kpi Status
    /// </summary>
    public const string Approved = "Approved";
    public const string Draft = "Draft";
    public const string New = "New";
    public const string Submitted = "Submitted";
    public const string InProgress = "InProgress";
    public const string Rejected = "REJECTED";
    public const string ReSubmitted = "ReSubmitted";
    public const string ReturnForUpdate = "ReturnForUpdate";


    /// <summary>
    ///  For Wf Stattus
    /// </summary>
    public const string ResubmittedFromDepManager = "RESUBMITTED_FROM_DEP_MANAGER";
    public const string ResubmittedFromDataEntry = "RESUBMITTED_FROM_DATA_ENTRY";
    public const string ReturnedForUpdate = "RETURNED_FOR_UPDATES";
    public const string ReturendForUpdatesByDepManager = "RETURNED_FOR_UPDATES_BY_DEP_MANAGER";
    public const string ReturendForUpdatesByStgManager = "RETURNED_FOR_UPDATES_BY_STG_MANAGER";
    public const string ApprovedByDepManager = "APPROVED_BY_DEP_MANAGER";
    public const string ApprovedByStgMnagaer = "APPROVED_BY_STG_MANAGER";
    public const string RejectedByStgAuditer = "REJECTED_BY_STG_AUDITER";
    public const string RejectedByDepManager = "REJECTED_BY_DEPARTMENT_MANAGER";
    public const string RejectedByStgManager = "REJECTED_BY_STG_MANAGER";

    /// <summary>
    /// For DashBord
    /// </summary>
    public const string SubmitStepCode = "SUBMIT";
    public const string ResubmitStepCode = "RESUBMIT";
    public const string ReturnForUpdateByStgAudStepCode = "RETURNED_FOR_UPDATES_BY_STG_AUDITER";
    public const string ReturnForUpdateByStgManagerStepCode = "RETURNED_FOR_UPDATES_BY_STG_MANAGER";
    public const string ApprovedByDepManagerStepCode = "APPROVED_BY_DEP_MANAGER";


    public const string StrategyDepartment = "StrategyDepartment";
    public const string HeadOfDepartment = "HeadOfDepartment";
    public const string DataEntry = "DataEntry";


    public const string DepManagerStepCode = "DepManager";
    public const string StgAudStepCode = "StgAuditor";

    public const string AddRequestType = "ADD_NEW_KPI";

    public static readonly IReadOnlyList<string> RejectStatusCode = new List<string>
    {
        Constant.RejectedByStgAuditer,
        Constant.RejectedByDepManager,
        Constant.RejectedByStgManager
    };


    ///
    /// For MathematicalEquationAb
    ///
    public const string ADevideB = "A/B";
    public const string AMultiB = "A*100";
    public const string APlusB = "A+B*100/100";



    ///
    /// For MeasurementCycle
    ///
    public const string Quarterly = "Quarterly";
    public const string Monthly = "Monthly";
    public const string Biannual = "Biannual";
    public const string Annual = "Annual";


    public const string StrategyDepartmentCode = "StrategyDepartment";

    public const string DataEntryRoleCode = "Data Entry";
    public const string HeadOfDepartmentRoleCode = "HeadOfDepartment";



    /// For Status
}
