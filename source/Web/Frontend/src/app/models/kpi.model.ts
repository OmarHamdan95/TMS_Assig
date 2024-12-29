import {OptionModel} from "../components/select/option.model";
import {RequestModel} from "./request.model";
import {UpdateRequestStatusModel} from "./request-status.model";

export class KpiModel {
    id?: number | null;
    number?: string | null;
    kpiType?: OptionModel | null;
    kpiTypeId?: number | null;
    type?: OptionModel | null;
    typeId?: number | null;
    measurementUnit?: OptionModel | null;
    measurementUnitId?: number | null;
    mathematicalEquationAb?: OptionModel | null;
    mathematicalEquationAbId?: number | null;
    nameAr?: string | null;
    nameEn?: string | null;
    descriptionAr?: string | null;
    descriptionEn?: string | null;
    measurementCycle?: OptionModel | null;
    measurementCycleId?: number | null;
    descriptionAAr?: string | null;
    descriptionAEn?: string | null;
    descriptionBAr?: string | null;
    descriptionBEn?: string | null;
    //addedbyMalek
    inputMethod?: OptionModel | null;
    inputMethodId?: number | null;
    aggregateCoefficientValuesMethodA?: OptionModel | null;
    aggregateCoefficientValuesMethodAId?: number | null;
    aggregateCoefficientValuesMethodB?: OptionModel | null;
    aggregateCoefficientValuesMethodBId?: number | null;
    initiaterNotes?: string | null;
    //end
    indicatorModularity?: OptionModel | null;
    indicatorModularityId?: number | null;
    isPrivet?: boolean | null;
    statisticalIndicator?: boolean | null;
    indexCreationRate?: OptionModel | null;
    indexCreationRateId?: number | null;
    indexSource?: OptionModel | null;
    indexSourceId?: number | null;
    indexClass?: OptionModel | null;
    indexClassId?: number | null;
    balancedScored?: OptionModel | null;
    balancedScoredId?: number | null;
    relatedStratigicGoal?: OptionModel | null;
    relatedStratigicGoalId?: number | null;
    firstResultSource?: OptionModel | null;
    firstResultSourceId?: number | null;
    firstResult?: number | null;
    firstResultDetails?: string | null;
    ownerDepartemnt?: OptionModel | null;
    ownerDepartemntId?: number | null;
    operationAction?: OptionModel | null;
    operationActionId?: number | null;
    reqeust!: RequestModel;
    reqeustId!: number;
    status?: OptionModel | null;
    statusId?: number | null;
    startDate?: Date | null;
    endDate?: Date | null;

    politics?: OptionModel | null;
    politicsId?: number | null;

    qualityOfLife?: OptionModel | null;
    qualityOfLifeId?: number | null;

    risk?: OptionModel | null;
    riskId?: number | null;

    sustainableDevelopmentGoals?: OptionModel | null;
    sustainableDevelopmentGoalsId?: number | null;

    polarity?: OptionModel | null;
    polarityId?: number | null;
}


export class KpiResultModel {
    id?: number | null;
    number?: string | null;
    type?: OptionModel | null;
    kpiType?: OptionModel | null;
    kpiTypeId?: number | null;
    aggregateCoefficientValuesMethodAId?: number | null;
    aggregateCoefficientValuesMethodBId?: number | null;
    inputMethodId?: number | null;
    typeId?: number | null;
    measurementUnit?: OptionModel | null;
    measurementUnitId?: number | null;
    mathematicalEquationAb?: OptionModel | null;
    mathematicalEquationAbId?: number | null;
    nameAr?: string | null;
    nameEn?: string | null;
    descriptionAr?: string | null;
    descriptionEn?: string | null;
    measurementCycle?: OptionModel | null;
    measurementCycleId?: number | null;
    descriptionAAr?: string | null;
    descriptionAEn?: string | null;
    descriptionBAr?: string | null;
    descriptionBEn?: string | null;
    indicatorModularity?: OptionModel | null;
    indicatorModularityId?: number | null;
    isPrivet?: boolean | null;
    statisticalIndicator?: boolean | null;
    indexCreationRate?: OptionModel | null;
    indexCreationRateId?: number | null;
    indexSource?: OptionModel | null;
    indexSourceId?: number | null;
    indexClass?: OptionModel | null;
    indexClassId?: number | null;
    balancedScored?: OptionModel | null;
    balancedScoredId?: number | null;
    relatedStratigicGoal?: OptionModel | null;
    relatedStratigicGoalId?: number | null;
    firstResultSource?: OptionModel | null;
    firstResultSourceId?: number | null;
    firstResult?: number | null;
    firstResultDetails?: string | null;
    ownerDepartemnt?: OptionModel | null;
    ownerDepartemntId?: number | null;
    operationAction?: OptionModel | null;
    operationActionId?: number | null;
    reqeustId!: number;
    status?: OptionModel | null;
    statusId?: number | null;
    startDate?: Date;
    endDate?: Date;
    politics?: OptionModel | null;
    politicsId?: number | null;

    qualityOfLife?: OptionModel | null;
    qualityOfLifeId?: number | null;

    risk?: OptionModel | null;
    riskId?: number | null;

    sustainableDevelopmentGoal?: OptionModel | null;
    sustainableDevelopmentGoalId?: number | null;

    polarity?: OptionModel | null;
    polarityId?: number | null;
}


export class KpiGridModel {
    id?: number;
    number?: string;
    type?: OptionModel;
    measurementCycle?: OptionModel;
    typeId?: number;
    measurementCycleId?: number;
    nameAr?: string;
    nameEn?: string;
    status?: OptionModel;
    statusId?: number;
    ownerDepartemnt?: OptionModel;
    ownerDepartemntId?: number;
    requestId?: number;
    startDate?: Date;
    endDate?: Date;
    kpiTypeId?: number;
    kpiType?: OptionModel;
    createdDate?: Date;
}


export class ResubmitKpi {
    item?: KpiModel;
    action?: UpdateRequestStatusModel;
}

export class KpiTaskListGridResult {
    id?: number;
    kpiId?: number;
    aValue?: number;
    bValue?: number;
    resultValue?: number;
    startDate?: Date;
    endDate?: Date;
    target?: number;
    verificationRate?: number;
    isLocked? :boolean;
}

export class SaveResultModel {
    items?: Array<KpiTaskListGridResult>;
    result? :number;
    percent? :number;

}
