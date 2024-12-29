import {Routes} from "@angular/router";

export const ROLES_ROUTES: Routes = [
    {
        path: "list",
        loadComponent: () => import("../roles/roles.component").then((response) => response.AppRolesListComponent),
    },
    {
        path: "create",
        loadComponent: () => import("../roles/create/create-roles.component").then((response) => response.AppCreateRolesComponent)
    },
    {
        path: ":id/permissions",
        loadComponent: () => import("../roles/permissions-grid/permissions-grid.component").then((response) => response.AppPermissionsGridComponent),
    },
    {
        path: ":id/create",
        loadComponent: () => import("../roles/create-permission/create-permission.component").then((response) => response.AppCreatePermissionComponent),
    }
]
