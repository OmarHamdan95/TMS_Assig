import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import {MenuGroup, MenuItem} from "../layouts/sidebar/menu";
import { GridParametersModel } from "../components/grid/grid-parameters.model";

@Injectable({ providedIn: "root" })
export class SystemMenuService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
    ) { }

    add = (menu: MenuItem) => this.http.post<number>(`${this.config.apiUrl}api/systemMenu`, menu);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/systemMenu/${id}`);

    get = (id: number) => this.http.get<MenuItem>(`${this.config.apiUrl}api/systemMenu/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<MenuItem>>(`${this.config.apiUrl}api/systemMenu/grid`, parameters);

    //inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/systemMenu/${id}/inactivate`, {});

    list = (moduleCode: string) => this.http.get<MenuGroup[]>(`${this.config.apiUrl}api/systemMenu/list/${moduleCode}`);

    //update = (menu: MenuItem) => this.http.put(`${this.config.apiUrl}api/systemMenu/${menu.id}`, menu);
}
