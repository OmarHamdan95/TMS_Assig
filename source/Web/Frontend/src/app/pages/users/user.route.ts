import {Routes} from "@angular/router";

export const USER_ROUTES: Routes = [
    {
        path: "list",
        loadComponent: () => import("../users/users.component").then((response) => response.AppUsersListComponent),
    },
    {
        path: "create",
        loadComponent: () => import("../users/create/create-user.component").then((response) => response.AppCreateUserComponent)
    },
    {
        path: "update/:id",
        loadComponent: () => import("../users/edit/update-user.component").then((response) => response.AppUpdateUserComponent)
    }
]
