import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";
import { LookupValueModel } from "../models/lookup-value.model";


@Injectable({ providedIn: "root" })
export class AppLookupValueService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
      ) { }

    add = (lookup: LookupValueModel) => this.http.post<number>(`${this.config.apiUrl}api/lookup-value`, lookup);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/lookup-value/${id}`);

    get = (id: number) => this.http.get<LookupValueModel>(`${this.config.apiUrl}api/lookup-value/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<LookupValueModel>>(`${this.config.apiUrl}api/lookup-value/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/lookup-value/${id}/inactivate`, {});

    list = () => this.http.get<LookupValueModel[]>(`${this.config.apiUrl}api/lookup-value/list`);

    update = (user: LookupValueModel) => this.http.put(`${this.config.apiUrl}api/lookup-value/${user.id}`, user);
}
