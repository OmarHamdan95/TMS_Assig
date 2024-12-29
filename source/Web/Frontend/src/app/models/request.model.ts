import {ReqeustStatusResultModel} from "./request-status.model";
import {RequestTypeResultModel} from "./reqeust-type.model";

export class RequestModel {
    id?: number | null;
    externalId?: number | null;
    status?: ReqeustStatusResultModel | null;
    type?: RequestTypeResultModel | null;
    authorId?: string | null;
    authorType?: string | null;
    wfTransaction?: WfTransaction[];
}

export class WfTransaction {
    id?: number | null;
    requestId?: number | null;
    comment?: string;
    action?: string;
    createdBy?: string;
    createdDate?: Date;
    oldStatusCode?: string;
    oldStatusDescriptionAr?: string;
    oldStatusDescriptionEn?: string;
    newStatusCode?: string;
    newStatusDescriptionAr?: string;
    newStatusDescriptionEn?: string;
    departmentCode?: string;
    roleCode?: string;
}


export class RequestDataModel {
    id?: number | null;
    status?: ReqeustStatusResultModel | null;
    type?: RequestTypeResultModel | null;
    externalId?: number | null;
    data?:string;
    number?:string;
}
