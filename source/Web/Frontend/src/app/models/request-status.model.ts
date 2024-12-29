export class ReqeustStatusResultModel {
    code?: string | null;
    actionNameAr?: string | null;
    actionNameEn?: string | null;
    descriptionAr?: string | null;
    descriptionEn?: string | null;
    color?: string | null;
    cssClass?: string | null;
    icon?: string | null;
    roles?: string[] = [];
    nextStatusCodes: (string | null)[] = [];
    previousStatusCodes: (string | null)[] = [];
}


export class ReqeustStatusModel {
    id?:number;
    code?: string | null;
    actionNameAr?: string | null;
    actionNameEn?: string | null;
    descriptionAr?: string | null;
    descriptionEn?: string | null;
    color?: string | null;
    cssClass?: string | null;
    icon?: string | null;

}


export class UpdateRequestStatusModel {
    requestId? : number;
    status? : ReqeustStatusModel;
    note? : string;
}
