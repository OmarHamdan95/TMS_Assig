import {HttpClient} from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import {CONFIGURATIONS} from "../settings/configuration";
import {DepartmentModel} from "../models/department.model";
import {
    DashbordByDepratmentModel,
    DashbordKpiTaskResultModel,
    DashbordRequestByStepModel
} from "../models/dashbordModel";


@Injectable({providedIn: "root"})
export class AppDashboardService {
    config = inject(CONFIGURATIONS);

    constructor (
        private readonly http: HttpClient
    ) {
    }

    getCountActive = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountActive`);
    getCountKpiTasks = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountKpiTasks`);

    getCountDraftKpi = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountDraftKpi`);
    getCountWfStageByStep = (step: string) => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountWfStageByStep/${step}`);

    getCountMyTask = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountMyTask`);
    getCountTask = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountTask`);
    getCountDoneTask = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountDoneTask`);
    getCountDelayedTask = () => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/dashboard/CountDelayedTask`);
    CountKpiByDepartment = (item: any) =>
        this.http.post<DashbordByDepratmentModel[]>(`${this.config.apiUrl}api/dashboard/CountKpiByDepartment`, item);

    KpiResult = (item?: any) =>
        this.http.post<DashbordKpiTaskResultModel[]>(`${this.config.apiUrl}api/dashboard/KpiResult`, item);

    getRequestByStepCount =() => this.http.get<DashbordRequestByStepModel[]>(`${this.config.apiUrl}api/dashboard/KpiRequestByStep`);
}
