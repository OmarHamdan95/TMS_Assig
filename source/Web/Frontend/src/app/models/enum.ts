export enum UserStatusEnum {
    none = 0,
    active = 1,
    inActive = 2
}


export enum KpiStatusEnum {
    Draft = "Draft",
    Approved = "Approved",
    Submitted = "Submitted",
    ReSubmitted = "ReSubmitted",
    Rejected ="Rejected",
    InProgress ="InProgress",
    "ReturnForUpdate" ="ReturnForUpdate"
}
export enum KpiStatusIdsEnum {
    Draft = 35,
    Approved = 36,
    Submit = 37,
    ReSubmitted = 38,
    Rejected = 39,
    InProgress = 40,
    ReturnForUpdate = 41
}


export enum mathematicalEquationAbIdsEnum{
    "A/B*100" = 42,
    "A*100" =43,
    "A+B*100/100"=44
}


export const EditableStatusCode =["RETURNED_FOR_UPDATES_BY_DEP_MANAGER" , "RETURNED_FOR_UPDATES_BY_STG_AUDITER", "RETURNED_FOR_UPDATES_BY_STG_MANAGER"]
