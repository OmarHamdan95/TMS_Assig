import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import {
    KpiGridModel,
    KpiModel,
    KpiResultModel,
    KpiTaskListGridResult,
    ResubmitKpi,
    SaveResultModel
} from "../models/kpi.model";
import {GridParametersModel} from "../components/grid/grid-parameters.model";
import {BehaviorSubject} from "rxjs";

@Injectable({ providedIn: "root" })
export class AppKpiService {
    config = inject(CONFIGURATIONS);

    private savedButtonClick = new BehaviorSubject<boolean>(false);

    btnClicked = this.savedButtonClick.asObservable();
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
    ) { }

    add = (kpi: KpiModel) => this.http.post<number>(`${this.config.apiUrl}api/kpi`, kpi);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/kpi/${id}`);

    get = (id: number) => this.http.get<KpiResultModel>(`${this.config.apiUrl}api/kpi/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<KpiGridModel>>(`${this.config.apiUrl}api/kpi/grid`, parameters);

    list = () => this.http.get<KpiModel[]>(`${this.config.apiUrl}api/kpi/list`);

    update = (kpi: KpiModel) => this.http.put(`${this.config.apiUrl}api/kpi/update`, kpi);

    tasks = (parameters: GridParametersModel) => this.gridService.get<BaseResult<KpiGridModel>>(`${this.config.apiUrl}api/kpi/tasks`, parameters);

    activeList = (parameters: GridParametersModel) => this.gridService.get<BaseResult<KpiGridModel>>(`${this.config.apiUrl}api/kpi/active-list`, parameters);
    activeListNeedFill = (parameters: GridParametersModel) => this.gridService.get<BaseResult<KpiGridModel>>(`${this.config.apiUrl}api/kpi/fill-active-list`, parameters);
    KpiTaskListGrid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<KpiTaskListGridResult>>(`${this.config.apiUrl}api/kpi/gridTaskListResult`, parameters);

    submit = (id?:number) => this.http.post<number>(`${this.config.apiUrl}api/kpi/Submit/${id}`, null);

    updateResubmit = (item: ResubmitKpi) => this.http.put(`${this.config.apiUrl}api/kpi/update-resubmit`,item );

    saveResult = (items : SaveResultModel) => this.http.put(`${this.config.apiUrl}api/kpi/saveResult`, items);

    onButtonSaveClicked =(isClicked:  boolean) => this.savedButtonClick.next(isClicked);
}
