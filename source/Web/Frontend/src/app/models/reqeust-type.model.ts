import {ReqeustStatusModel} from "./request-status.model";

export class RequestTypeResultModel {
    code?: string | null;
    nameAr?: string | null;
    nameEn?: string | null;
    statuses: (ReqeustStatusModel | null)[] = [];
}
