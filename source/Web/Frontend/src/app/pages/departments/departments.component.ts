import { Component } from "@angular/core";
import {RouterLink} from "@angular/router";
import { AppCreateDepartmentsComponent } from "./create/create-departments.component";
import { AppDepartmentsGridComponent } from "./departments-grid/departments-grid.component";
import {TranslateModule} from "@ngx-translate/core";
@Component({
    selector: "app-departments",
    templateUrl: "./departments.component.html",
    standalone: true,
    imports: [
        AppDepartmentsGridComponent,
        AppCreateDepartmentsComponent,
        RouterLink,
        TranslateModule
    ]
})
export class AppDepartmentsListComponent { }
