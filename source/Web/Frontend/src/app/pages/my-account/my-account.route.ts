import {Routes} from "@angular/router";

export const MY_ACCOUNT_ROUTES: Routes = [
    {
        path: "",
        loadComponent: () => import("../my-account/my-account.component").then((response) => response.AppMyAccountComponent),
    }
]
