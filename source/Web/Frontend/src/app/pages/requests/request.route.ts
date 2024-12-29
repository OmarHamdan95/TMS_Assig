import {Routes} from "@angular/router";

export const REQUEST_ROUTES: Routes = [
    {
        path: "list",
        loadComponent: () => import("../requests/request.component").then((response) => response.AppReqeustListComponent),
    },
    {
        path: "view/:id",
        loadComponent: () => import("../requests/view/requests-view.component").then((response) => response.AppReqeustViewComponent),
    },
    // {
    //     path: "update/:id",
    //     loadComponent: () => import("../kpis/view/kpis-view.component").then((response) => response.AppKpisViewComponent),
    //     data:
    //         { isUpdateMode: true }
    // },
    // {
    //     path: "create",
    //     loadComponent: () => import("../kpis/create/create-kpi.component").then((response) => response.AppCreateKpiComponent),
    //
    // },
    // {
    //     path: "tasks-list",
    //     loadComponent: () => import("../kpis/kpis-tasks-list/kpis-tasks-list.component").then((response) => response.AppKpisTasksListComponent),
    // },
    // {
    //     path: "active-list",
    //     loadComponent: () => import("../kpis/kpis-active-list/kpis-active-list.component").then((response) => response.AppKpisActiveListComponent),
    // },

]
