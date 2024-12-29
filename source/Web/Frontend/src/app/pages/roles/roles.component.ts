import { Component } from "@angular/core";
import {RouterLink} from "@angular/router";
import { AppRolesGridComponent } from "./roles-grid/roles-grid.component";
import { AppCreateRolesComponent } from "./create/create-roles.component";
import {TranslateModule} from "@ngx-translate/core";
@Component({
    selector: "app-roles",
    templateUrl: "./roles.component.html",
    standalone: true,
    imports: [
        AppRolesGridComponent,
        AppCreateRolesComponent,
        RouterLink,
        TranslateModule
    ]
})
export class AppRolesListComponent { }
