import {HttpClient} from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import {GridParametersModel} from "../components/grid/grid-parameters.model";
import {RequestDataModel, RequestModel, WfTransaction} from "../models/request.model";
import {UpdateRequestStatusModel} from "../models/request-status.model";

@Injectable({providedIn: "root"})
export class AppReqeustService {
    config = inject(CONFIGURATIONS);

    constructor (
        private readonly http: HttpClient,
        private gridService: GridService
    ) {
    }

    add = (request: RequestModel) => this.http.post<number>(`${this.config.apiUrl}api/reqeust`, request);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/reqeust/${id}`);

    get = (id: number) => this.http.get<RequestDataModel>(`${this.config.apiUrl}api/reqeust/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<RequestModel>>(`${this.config.apiUrl}api/reqeust/grid`, parameters);


    gridWfTransaction = (parameters: GridParametersModel) => this.gridService.get<BaseResult<WfTransaction>>(`${this.config.apiUrl}api/reqeust/gridWf`, parameters);

    list = () => this.http.get<RequestModel[]>(`${this.config.apiUrl}api/reqeust/list`);

    update = (request: RequestModel) => this.http.put(`${this.config.apiUrl}api/reqeust/${request.id}`, request);

    updateStatus = (action: UpdateRequestStatusModel) => this.http.put(`${this.config.apiUrl}api/reqeust/updateStatus`, action);


}
