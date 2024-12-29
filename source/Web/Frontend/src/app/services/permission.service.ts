import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import { PermissionModel } from "../models/permission.model";


@Injectable({ providedIn: "root" })
export class AppPermissionService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
      ) { }

    add = (lookup: PermissionModel) => this.http.post<number>(`${this.config.apiUrl}api/permission`, lookup);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/permission/${id}`);

    get = (id: number) => this.http.get<PermissionModel>(`${this.config.apiUrl}api/permission/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<PermissionModel>>(`${this.config.apiUrl}api/permission/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/permission/${id}/inactivate`, {});

    list = () => this.http.get<PermissionModel[]>(`${this.config.apiUrl}api/permission/list`);

    update = (user: PermissionModel) => this.http.put(`${this.config.apiUrl}api/permission/${user.id}`, user);
}
