import { Component } from "@angular/core";
import {RouterLink} from "@angular/router";
import {TranslateModule} from "@ngx-translate/core";
import {AppRequestsGridComponent} from "./reqeusts-grid/requests-grid.component";
@Component({
    selector: "app-request",
    templateUrl: "./request.component.html",
    standalone: true,
    imports: [
        RouterLink,
        TranslateModule,
        AppRequestsGridComponent
    ]
})
export class AppReqeustListComponent { }
