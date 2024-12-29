import { Component } from "@angular/core";
import {RouterLink} from "@angular/router";
import { AppLookupsGridComponent } from "./lookups-grid/lookups-grid.component";
import { AppCreateLookupComponent } from "./create/create-lookup.component";
import { TranslateModule } from "@ngx-translate/core";
@Component({
    selector: "app-lookups",
    templateUrl: "./lookups.component.html",
    standalone: true,
    imports: [
        AppLookupsGridComponent,
        AppCreateLookupComponent,
        RouterLink,
        TranslateModule
    ]
})
export class AppLookupsListComponent { }
