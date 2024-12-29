import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import { DepartmentModel } from "../models/department.model";



@Injectable({ providedIn: "root" })
export class AppDepartmentService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
      ) { }

    add = (department: DepartmentModel) => this.http.post<number>(`${this.config.apiUrl}api/department`, department);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/department/${id}`);

    get = (id: number) => this.http.get<DepartmentModel>(`${this.config.apiUrl}api/department/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<DepartmentModel>>(`${this.config.apiUrl}api/department/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/department/${id}/inactivate`, {});

    list = () => this.http.get<DepartmentModel[]>(`${this.config.apiUrl}api/department/list`);

    update = (user: DepartmentModel) => this.http.put(`${this.config.apiUrl}api/department/${user.id}`, user);
}
