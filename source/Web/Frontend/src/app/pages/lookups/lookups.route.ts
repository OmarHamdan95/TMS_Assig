import {Routes} from "@angular/router";

export const LOOKUPS_ROUTES: Routes = [
    {
        path: "list",
        loadComponent: () => import("../lookups/lookups.component").then((response) => response.AppLookupsListComponent),
    },
    {
        path: "create",
        loadComponent: () => import("../lookups/create/create-lookup.component").then((response) => response.AppCreateLookupComponent)
    },
    {
        path: ":id/childs",
        loadComponent: () => import("../lookups/lookup-values-grid/lookup-values-grid.component").then((response) => response.AppLookupValuesGridComponent),
    },
    {
        path: ":id/create",
        loadComponent: () => import("../lookups/create-lookup-value/create-lookup-value.component").then((response) => response.AppCreateLookupValueComponent),
    }
]
