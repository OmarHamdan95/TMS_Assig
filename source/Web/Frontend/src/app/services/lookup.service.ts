import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import { LookupModel } from "../models/lookup.model";



@Injectable({ providedIn: "root" })
export class AppLookupService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
      ) { }

    add = (lookup: LookupModel) => this.http.post<number>(`${this.config.apiUrl}api/lookup`, lookup);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/lookup/${id}`);

    get = (id: number) => this.http.get<LookupModel>(`${this.config.apiUrl}api/lookup/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<LookupModel>>(`${this.config.apiUrl}api/lookup/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/lookup/${id}/inactivate`, {});

    list = () => this.http.get<LookupModel[]>(`${this.config.apiUrl}api/lookup/list`);

    update = (user: LookupModel) => this.http.put(`${this.config.apiUrl}api/lookup/${user.id}`, user);
}
