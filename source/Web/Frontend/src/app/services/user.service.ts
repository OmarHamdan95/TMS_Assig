import { HttpClient } from "@angular/common/http";
import {inject, Injectable} from "@angular/core";
import { GridParametersModel } from "src/app/components/grid/grid-parameters.model";
import {UpdatePasswordModel, UserModel} from "src/app/models/user.model";
import {GridService} from "../components/grid/grid.service";
import {BaseResult} from "../models/baseResult";
import {CONFIGURATIONS} from "../settings/configuration";

@Injectable({ providedIn: "root" })
export class AppUserService {
    config = inject(CONFIGURATIONS);
    constructor(
        private readonly http: HttpClient,
        private gridService: GridService
      ) { }

    add = (user: UserModel) => this.http.post<number>(`${this.config.apiUrl}api/users`, user);

    delete = (id: number) => this.http.delete(`${this.config.apiUrl}api/users/${id}`);

    get = (id: number) => this.http.get<UserModel>(`${this.config.apiUrl}api/users/${id}`);

    grid = (parameters: GridParametersModel) => this.gridService.get<BaseResult<UserModel>>(`${this.config.apiUrl}api/users/grid`, parameters);

    inactivate = (id: number) => this.http.patch(`${this.config.apiUrl}api/users/${id}/inactivate`, {});

    list = () => this.http.get<UserModel[]>(`${this.config.apiUrl}api/users/list`);

    update = (user: UserModel) => this.http.put(`${this.config.apiUrl}api/users/${user.id}`, user);
    updatePassword = (user: UpdatePasswordModel) => this.http.put(`${this.config.apiUrl}api/users/changePassword`, user);
}
