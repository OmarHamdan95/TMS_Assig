export enum WFStatus {
    SUBMIT = "SUBMIT",
    RETURNED_FOR_UPDATES_BY_DEP_MANAGER = "RETURNED_FOR_UPDATES_BY_DEP_MANAGER",
    RESUBMIT = "RESUBMIT",
    REJECTED_BY_DEPARTMENT_MANAGER = "REJECTED_BY_DEPARTMENT_MANAGER",
    APPROVED_BY_DEP_MANAGER = "APPROVED_BY_DEP_MANAGER",
    RETURNED_FOR_UPDATES_BY_STG_AUDITER = "RETURNED_FOR_UPDATES_BY_STG_AUDITER",
    REJECTED_BY_STG_AUDITER = "REJECTED_BY_STG_AUDITER",
    APPROVED_BY_STG_AUDITER = "APPROVED_BY_STG_AUDITER",
    RETURNED_FOR_UPDATES_BY_STG_MANAGER = "RETURNED_FOR_UPDATES_BY_STG_MANAGER",
    REJECTED_BY_STG_MANAGER = "REJECTED_BY_STG_MANAGER",
    APPROVED_BY_STG_MANAGER = "APPROVED_BY_STG_MANAGER",
    depManager = "DepManager",
    stgAuditor = "StgAuditor"
}