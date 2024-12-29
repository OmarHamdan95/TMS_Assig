import { Component } from "@angular/core";
import { AppUsersGridComponent } from "./users-grid/users-grid.component";
import { AppCreateUserComponent } from "./create/create-user.component";
import {RouterLink} from "@angular/router";
import {TranslateModule} from "@ngx-translate/core";
@Component({
    selector: "app-users",
    templateUrl: "./users.component.html",
    standalone: true,
    imports: [
        AppUsersGridComponent,
        AppCreateUserComponent,
        RouterLink,
        TranslateModule
    ]
})
export class AppUsersListComponent { }
