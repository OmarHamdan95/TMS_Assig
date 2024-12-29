import { Component } from "@angular/core";
import {RouterLink} from "@angular/router";
import {AppKpisGridComponent} from "./kpis-grid/kpis-grid.component";
import {TranslateModule} from "@ngx-translate/core";
@Component({
    selector: "app-kpi",
    templateUrl: "./kpi.component.html",
    standalone: true,
    imports: [
        RouterLink,
        AppKpisGridComponent,
        TranslateModule
    ]
})
export class AppKpiListComponent { }
