import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import { RoleModel } from "../models/role.model";



@Injectable({ providedIn: "root" })
export class AppRoleService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
      ) { }

    add = (role: RoleModel) => this.http.post<number>(`${this.config.apiUrl}api/role`, role);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/role/${id}`);

    get = (id: number) => this.http.get<RoleModel>(`${this.config.apiUrl}api/role/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<RoleModel>>(`${this.config.apiUrl}api/role/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/role/${id}/inactivate`, {});

    list = () => this.http.get<RoleModel[]>(`${this.config.apiUrl}api/role/list`);

    update = (user: RoleModel) => this.http.put(`${this.config.apiUrl}api/role/${user.id}`, user);
}
