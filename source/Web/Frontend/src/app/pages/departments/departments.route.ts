import {Routes} from "@angular/router";

export const DEPARTMENTS_ROUTES: Routes = [
    {
        path: "list",
        loadComponent: () => import("../departments/departments.component").then((response) => response.AppDepartmentsListComponent),
    },
    {
        path: "create",
        loadComponent: () => import("../departments/create/create-departments.component").then((response) => response.AppCreateDepartmentsComponent)
    }
    //{
    //    path: ":id/childs",
    //    loadComponent: () => import("../lookups/lookup-values-grid/lookup-values-grid.component").then((response) => response.AppLookupValuesGridComponent),
    //},
    //{
    //    path: ":id/create",
    //    loadComponent: () => import("../lookups/create-lookup-value/create-lookup-value.component").then((response) => response.AppCreateLookupValueComponent),
    //}
]
